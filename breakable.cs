using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> breakablePieces;
   // public float timetobreak = 2;
    //public float timer = 0;

    void Start()

    {

        foreach (var item in breakablePieces)
        {
            item.SetActive(false);
        }



    }
    public void Break()
    {
       /* timer += Time.deltaTime;

        if (timer > timetobreak)
        {
        }*/

        foreach (var item in breakablePieces)
        {
            item.SetActive(true);
            item.transform.parent = null;
        }
        gameObject.SetActive(false);


    }



}
