using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Box_Drop_Handler : MonoBehaviour, IDropHandler
{

    private void Awake() {

    }

    public void OnDrop(PointerEventData eventData){
        Debug.Log("OnDrop Seggs");
        if(eventData.pointerDrag != null){
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

}