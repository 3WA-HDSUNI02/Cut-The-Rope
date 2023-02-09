using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CutOnClick : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {

        Debug.Log("CLICK");

    }


    private void OnMouseDown()
    {
        Debug.Log("CLICK");

    }
}
