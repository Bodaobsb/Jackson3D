using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
    GameObject item;
    public Image icon;
    Item _item;

    public Button removeButton;


    public void AddItem(GameObject newItem)
    {
        
        item = newItem;
        _item = item.GetComponent<Item>();
        icon.sprite =  _item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        _item.Use();
    }

}
