using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class BoatMoveController : MonoBehaviour
{
    public Transform boatWheel;
    public Transform boat;

    void Update()
    {
        float wheelRotation = boatWheel.localEulerAngles.z; // Get wheel rotation
        float steerAmount = Mathf.Clamp(wheelRotation, -45, 45); // Limit turning
        boat.Rotate(0, steerAmount * Time.deltaTime, 0); // Rotate the boat
    }
}
