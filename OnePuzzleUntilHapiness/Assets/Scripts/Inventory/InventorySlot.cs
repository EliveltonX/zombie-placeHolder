using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image icon;
    public Button DeleteBtn;

    public void AddItem(Item newItem) 
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        DeleteBtn.interactable = true;
    }

    public void ClearSlot() 
    {
        icon.sprite = null;
        icon.enabled = false;
        DeleteBtn.interactable = false;
    }

    public void UseItem() 
    {
        if (item != null) 
        {
            item.Use();
        }
    }

    public void OnRemoveItem() 
    {
        Inventory.instance.Remove(item);
    }
}
