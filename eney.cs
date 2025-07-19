using System.Collections;
using UnityEngine;

public class eney : MonoBehaviour
{
    public GameObject _target;
    public Animator _playeranimator;
    public float triggerRadius = 15.0f;
    public float resetCollisionDistance = 2.0f;
    public Transform target;

    public AudioSource voiceAudioSource;
    public ParticleSystem hitParticle1;
    public ParticleSystem hitParticle2;

    public float hitStateDuration = 2.0f;

    public GameObject state1Object;        // 🔵 Active only during state 1

    private bool hasCollided = false;
    private bool isInHitState = false;
    private bool isState3Locked = false;

    void Update()
    {
        if (isInHitState || isState3Locked) return;

        float distance = Vector3.Distance(target.position, transform.position);

        // Change direction of this.gameObject towards the target
        Vector3 direction = target.position - transform.position;
        direction.y = 0;  // Optional: Lock rotation on the y-axis to prevent tilting
        transform.forward = direction.normalized;  // Update the object's rotation

        if (!hasCollided || distance > resetCollisionDistance)
        {
            if (distance > resetCollisionDistance)
            {
                hasCollided = false;
            }

            if (distance <= triggerRadius && !hasCollided)
            {
                _playeranimator.SetInteger("state", 1);

                if (!voiceAudioSource.isPlaying)
                {
                    voiceAudioSource.Play();
                }

                // 🔵 Activate object during state 1
                if (state1Object != null && !state1Object.activeSelf)
                {
                    state1Object.SetActive(true);
                }
            }
            else
            {
                _playeranimator.SetInteger("state", 0);

                if (voiceAudioSource.isPlaying)
                {
                    voiceAudioSource.Stop();
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            Debug.Log("Bullet Triggered!");

            hasCollided = true;
            isInHitState = true;

            _playeranimator.SetInteger("state", 2);

            // 🔴 Deactivate object during state 2
            if (state1Object != null && state1Object.activeSelf)
            {
                state1Object.SetActive(false);
            }

            if (hitParticle1 != null) hitParticle1.Play();
            if (hitParticle2 != null) hitParticle2.Play();

            StartCoroutine(ResetHitStateAfterDelay());
        }
    }

    IEnumerator ResetHitStateAfterDelay()
    {
        yield return new WaitForSeconds(hitStateDuration);

        // Lock in state 3
        _playeranimator.SetInteger("state", 3);
        isInHitState = false;
        isState3Locked = true;

        // Move Y to -23.97
        Vector3 pos = transform.position;
        pos.y = -23.32f;
        transform.position = pos;

        Debug.Log("Locked in State 3 and moved Y to -23.97");
    }
}
