using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public DragAndDrop Item;
    public Transform parentOfSlots;

    public override void Interact()
    {
        parentOfSlots = Inventory.instance.invParent.transform;
        ItemSlot[] slots = parentOfSlots.GetComponentsInChildren<ItemSlot>();
        ItemSlot[] freeSlots = new ItemSlot[10];

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null) 
            {
                GameObject item = Instantiate(Item.gameObject);
                item.transform.SetParent(slots[i].transform);
                item.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                Debug.Log("Pegou");
                Destroy(gameObject);
            }
        } 
    }
}
