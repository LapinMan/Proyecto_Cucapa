using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Obj : MonoBehaviour
{
    private int slots;
    // Start is called before the first frame update
    void Start()
    {
        // Generate Boxes for inventory
        slots = 4;
        for(int i = 0; i<slots; i++){
            GameObject newBox = new GameObject("Box_" +i);
            newBox.AddComponent<Image>();
            newBox.transform.SetParent(this.transform);
            // Set Transforms
            newBox.GetComponent<RectTransform>().sizeDelta = new Vector2(75, 75);
            newBox.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            newBox.GetComponent<RectTransform>().localPosition = new Vector3(newBox.GetComponent<RectTransform>().localPosition.x,
                 newBox.GetComponent<RectTransform>().localPosition.y,
                0f);   

            // Set image properties
             newBox.GetComponent<Image>().color = new Color32(0,0,0,255);
        }
    }

}
