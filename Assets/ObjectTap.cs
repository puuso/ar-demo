using UnityEngine;

public class ObjectTap : MonoBehaviour
{
    public GameObject TappedObject;
    public GameObject TappedObjectInfo;

    private void Start()
    {
        TappedObject.SetActive(false);
        TappedObjectInfo.SetActive(false);
    }
    private void OnMouseDown()
    {
        //mobile
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && !TappedObject.activeSelf && !TappedObjectInfo.activeSelf)
        {
            TappedObject.SetActive(true);
            TappedObjectInfo.SetActive(true);
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && TappedObject.activeSelf && TappedObjectInfo.activeSelf)
        {
            TappedObject.SetActive(false);
            TappedObjectInfo.SetActive(false);
        }
        //debug for mouse
        if (Input.GetMouseButtonDown(0) && !TappedObject.activeSelf && !TappedObjectInfo.activeSelf)
        {
            TappedObject.SetActive(true);
            TappedObjectInfo.SetActive(true);
        }
        else if (Input.GetMouseButtonDown(0) && TappedObject.activeSelf && TappedObjectInfo.activeSelf)
        {
            TappedObject.SetActive(false);
            TappedObjectInfo.SetActive(false);
        }
    }
}