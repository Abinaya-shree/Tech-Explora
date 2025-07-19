using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashcan : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Triggerzone>().OnEnterEvent.AddListener(InsideTrash);
    }

    // Update is called once per frame
    public void InsideTrash(GameObject go)
    {
        go.SetActive(false);    
    }
}
