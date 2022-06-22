using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private int capacity;    

    private void Awake()
    {
        Instance = this;
        capacity = 8;
    }

    public bool Add(Item item)
    {
        print("Attempt to add item");
        if(items.Count < capacity){
            items.Add(item);
            return true;
        }
        return false;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void showInventory(){
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

            //print(itemName);

            //obj.GetComponent<Item>();

        }
    }
}
