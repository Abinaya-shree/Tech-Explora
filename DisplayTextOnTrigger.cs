using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayTextOnTrigger : MonoBehaviour
{
    // Reference to the UI Text or TextMeshProUGUI
    public TMP_Text referenceText;

    // The text you want to show when triggered
    [TextArea]
    public string message = "Hello! This is related text.";

    // The AudioSource to play when triggered
    public AudioSource audioSource;

    // The game object to activate or deactivate
    public GameObject objectToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Display the text
            if (referenceText)
            {
                referenceText.text = message;
                referenceText.gameObject.SetActive(true);
            }

            // Activate object
            if (objectToActivate)
            {
                objectToActivate.SetActive(true);
            }

            // Play Audio
            if (audioSource)
            {
                audioSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide the text
            if (referenceText)
            {
                referenceText.gameObject.SetActive(false);
            }

            // Deactivate object
            if (objectToActivate)
            {
                objectToActivate.SetActive(false);
            }

            // Stop Audio
            if (audioSource)
            {
                audioSource.Stop();
            }
        }
    }
}
