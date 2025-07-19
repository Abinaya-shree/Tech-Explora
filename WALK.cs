using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WALK : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector3.forward * 2.0f *  Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 2.0f * Time.deltaTime);
    }
}
