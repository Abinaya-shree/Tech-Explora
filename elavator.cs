using UnityEngine;

public class elavator : MonoBehaviour
{
    public Transform tp; // Reference to the tp target point
    public Transform b1; // Reference to the b1 target point

    public float radius = 5f; // Radius to check proximity
    public float moveSpeed = 10f; // Speed at which this component moves

    private bool moveUp = false; // Determines if the elevator should move up
    private bool moveDown = false; // Determines if the elevator should move down

    void Update()
    {
        // Check distance between this component and b1
        float distanceToB1 = Vector3.Distance(transform.position, b1.position);

        // Check distance between this component and tp
        float distanceToTP = Vector3.Distance(transform.position, tp.position);

        // If within radius of b1, set moveUp to true and moveDown to false
        if (distanceToB1 <= radius)
        {
            moveUp = true;
            moveDown = false;
        }
        // If within radius of tp, set moveDown to true and moveUp to false
        else if (distanceToTP <= radius)
        {
            moveDown = true;
            moveUp = false;
        }

        // Move the elevator based on the flags
        if (moveUp)
        {
            Move(Vector3.up);
        }
        else if (moveDown)
        {
            Move(Vector3.down);
        }
    }

    // Method to move this component
    private void Move(Vector3 direction)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
