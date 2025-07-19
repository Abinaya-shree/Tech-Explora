using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rcode : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 2f;

    void Update()
    {
        // Rotate the Earth around its Y-axis slowly
        transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
    }
}
