using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    public string targetTag = "Bullet";         // The tag to detect
    public ParticleSystem effectToPlay;         // Particle system to play

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Play the particle effect
            if (effectToPlay != null)
            {
                effectToPlay.Play();
            }

            // Destroy the target object
            Destroy(collision.gameObject); 
        }
        else
        {
            // Stop the particle effect if it's playing and not the target
            if (effectToPlay != null && effectToPlay.isPlaying)
            {
                effectToPlay.Stop();
            }
        }
    }



}
