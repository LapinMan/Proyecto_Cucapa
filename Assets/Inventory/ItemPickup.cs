using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void Pickup()
    {
        bool result = InventoryManager.Instance.Add(item);
        print("Resulted in: " +result);
        if(result) Destroy(gameObject);
    }

    private void OnClick()
    {
        Pickup();
        //print(Item.name);
    }
}
