using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFigure : MonoBehaviour
{
    Vector3 position;

    public int id;

    private void Start()
    {
        position = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DragObject") && id == 1)
        {
            collision.SendMessage("EnableDrop", position);
        }

        if (collision.CompareTag("DragObject2") && id == 2)
        {
            collision.SendMessage("EnableDrop", position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DragObject") && id == 1)
        {            
            collision.SendMessage("DisableDrop");
        }

        if (collision.CompareTag("DragObject2") && id == 2)
        {
            collision.SendMessage("DisableDrop");
        }
    }
}
