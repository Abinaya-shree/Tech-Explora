using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class VRLeverBoatMovement : MonoBehaviour
{
    public GameObject boat; // The boat object to move
    public XRLever lever; // The custom XRLever script
    public float maxSpeed = 10f; // Maximum boat speed

    private void Update()
    {
        if (lever == null || boat == null) return;

        // Get lever handle angle
        float leverAngle = lever.handle.localRotation.eulerAngles.x;

        // Convert angle range (0-360) to (-90 to 90)
        if (leverAngle > 180) leverAngle -= 360;

        // Map lever angle (-90 to 90) to speed (0 to 1)
        float speedFactor = Mathf.InverseLerp(-90f, 90f, leverAngle);

        // Apply speed
        float speed = speedFactor * maxSpeed;
        boat.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
