using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    // This method will be called when a collision occurs
    void OnCollisionEnter(Collision collision)
    {
        // If the colliding object is tagged "Fire", destroy it immediately
        if (collision.gameObject.CompareTag("Fire"))
        {
            Destroy(collision.gameObject);
        }
    }
}
