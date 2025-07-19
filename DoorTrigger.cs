using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour
{
    public Transform player; // Drag VR player here
    public Transform teleportLocation; // Set where player should go
    public GameObject referenceObject; // Assign your reference object in Inspector
    public Material newMaterial; // Drag your material here
    public AudioSource audioSource; // Assign an AudioSource with your sound
    public float teleportDelay = 3f; // Time to wait before teleporting

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player")) // Make sure your XR Rig is tagged "Player"
        {
            hasTriggered = true; // Prevent multiple triggers

            // Change the material of the reference object
            Renderer rend = referenceObject.GetComponent<Renderer>();
            if (rend != null && newMaterial != null)
            {
                rend.material = newMaterial;
            }

            // Play sound
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // Start teleport after delay
            StartCoroutine(TeleportAfterDelay());
        }
    }

    IEnumerator TeleportAfterDelay()
    {
        yield return new WaitForSeconds(teleportDelay);

        // Do the teleport
        player.position = teleportLocation.position;
        player.rotation = teleportLocation.rotation;

        Debug.Log("Welcome to the lab after a chill 3 seconds!");
    }
}
