using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour,IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;

    private bool enableDrop;

    Vector3 inicialPosition, newPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        inicialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (enableDrop)
        {
            transform.position = newPosition;
        }
        else
        {
            transform.position = inicialPosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {       
        rectTransform.anchoredPosition += new Vector2(eventData.delta.x, eventData.delta.y);
    }

    public void EnableDrop(Vector3 position)
    {
        newPosition = position;
        enableDrop = true;
    }

    public void DisableDrop()
    {
        enableDrop = false;
    }

}
