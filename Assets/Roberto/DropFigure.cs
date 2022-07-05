using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFigure : MonoBehaviour
{
    Vector3 position;

    public string nameObject;

    private void Start()
    {
        position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == nameObject)
        {
            collision.SendMessage("EnableDrop", position);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == nameObject)
        {            
            collision.SendMessage("DisableDrop");
        }

        //collision.CompareTag("DragObject")
    }
}
