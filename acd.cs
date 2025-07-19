using UnityEngine;

public class LeverBoatController : MonoBehaviour
{
    public GameObject boat; // Assign Boat Object
    public float moveSpeed = 5f; // Boat speed

    private bool moveForward = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Forward"))
        {
            moveForward = true; // Start moving
        }
        else if (other.CompareTag("Backward"))
        {
            moveForward = false; // Stop movement
        }
    }

    private void Update()
    {
        if (moveForward)
        {
            boat.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
