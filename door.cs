using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _doors;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            _doors.transform.Translate(Vector3.left * 5.0f);

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            _doors.transform.Translate(Vector3.right * 5.0f);

    }
}
