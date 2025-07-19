using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyscp : MonoBehaviour
{
    public GameObject particleEffect; // Assign your particle prefab in the inspector
    private Dictionary<GameObject, GameObject> activeParticles = new Dictionary<GameObject, GameObject>();

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle hit: " + other.gameObject.name);

        if (other.CompareTag("sd"))
        {
            if (!activeParticles.ContainsKey(other) || activeParticles[other] == null)
            {
                // Instantiate new particle effect at the collision point
                if (particleEffect != null)
                {
                    GameObject newEffect = Instantiate(particleEffect, other.transform.position, Quaternion.identity);
                    activeParticles[other] = newEffect; // Store reference
                }

                StartCoroutine(DestroyAfterDelay(other, 5f)); // 5 seconds delay
            }
        }
    }

    IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (obj != null) // ✅ Check if the object still exists
        {
            Debug.Log("Destroying: " + obj.name);
            Destroy(obj);
        }

        if (activeParticles.ContainsKey(obj))
        {
            if (activeParticles[obj] != null)
            {
                Destroy(activeParticles[obj]); // Destroy the particle effect as well
            }
            activeParticles.Remove(obj);
        }
    }
}
