using UnityEngine;

public class VRHandSimulator : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 1.5f;

    [Header("Rotation Settings")]
    public float rotationSpeed = 100f;
    public bool invertY = true;

    [Header("Optional Animator (for hand gestures)")]
    public Animator handAnimator;

    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleGestures();
    }

    void HandleMovement()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) move += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) move += Vector3.back;
        if (Input.GetKey(KeyCode.A)) move += Vector3.left;
        if (Input.GetKey(KeyCode.D)) move += Vector3.right;
        if (Input.GetKey(KeyCode.E)) move += Vector3.up;
        if (Input.GetKey(KeyCode.Q)) move += Vector3.down;

        transform.Translate(move * moveSpeed * Time.deltaTime, Space.Self);
    }

    void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y") * (invertY ? -1 : 1);

        Vector3 rotation = new Vector3(mouseY, mouseX, 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation, Space.Self);
    }

    void HandleGestures()
    {
        if (handAnimator == null) return;

        if (Input.GetKeyDown(KeyCode.G))
        {
            handAnimator.SetTrigger("Grab");
            Debug.Log("Gesture: Grab");
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            handAnimator.SetTrigger("Open");
            Debug.Log("Gesture: Open");
        }
    }
}
