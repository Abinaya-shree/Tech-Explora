using UnityEngine;

public class ProximityAudio : MonoBehaviour
{
    public Transform referenceObject; // The object to check distance to
    public float triggerRadius = 30f;
    public AudioSource audioSource;

    void Update()
    {
        if (referenceObject == null || audioSource == null) return;

        float distance = Vector3.Distance(transform.position, referenceObject.position);

        if (distance <= triggerRadius)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying)
                audioSource.Pause();
        }
    }
}
