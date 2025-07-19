using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class VRLeverBoatMovements : MonoBehaviour
{
    public GameObject boat; // Boat GameObject
    public XRLever lever; // Custom XRLever
    public float maxSpeed = 10f; // Max speed

    private void Update()
    {
        if (lever == null || boat == null) return;

        // Get lever rotation
        float leverAngle = lever.handle.localRotation.eulerAngles.x;

        // Convert (0 to 360) -> (-90 to 90)
        if (leverAngle > 180) leverAngle -= 360;

        // Map (-90 to 90) -> (-1 to 1)
        float speedFactor = Mathf.Clamp(leverAngle / 90f, -1f, 1f);

        // Move boat
        boat.transform.Translate(Vector3.forward * (speedFactor * maxSpeed * Time.deltaTime));
    }
}
