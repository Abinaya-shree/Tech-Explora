using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuctrl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _mainmenu,_gamemenu;
    void Start()
    {

    }

    // Update is called once per frame
    public void ButtonClick(GameObject UIobject)
    {
        if (UIobject.name == "start")
        {
            _mainmenu.SetActive(false);
            _gamemenu.SetActive(true);
        }

        if (UIobject.name == "exit")
        {
            Application.Quit();
        }
        if(UIobject.name == "home")
        {
            Application.LoadLevel(0);
        }
    }

}
