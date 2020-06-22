using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EquipmentSlotUI : MonoBehaviour
{
    Item item;
    public Image icon;

    public void AddItem(Item _newItem)
    {
        item = _newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        icon.sprite = null;
        icon.enabled = false;
    }

}
