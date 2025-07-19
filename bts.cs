using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class bts : MonoBehaviour
{
    public GameObject obj;
    public XRKnob knob;
    public float rotationSpeed = 100f; // Adjust this value to control speed

    private void Update()
    {
        float yRotation = knob.value * rotationSpeed;
        obj.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
