using UnityEngine;

public class ObjectToggle : MonoBehaviour
{
    public GameObject targetObject;

    // Call this to turn ON the object
    public void TurnOnObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
    }

    // Call this to turn OFF the object
    public void TurnOffObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }
}
