using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
   

    public Transform ItemsParent;
    public GameObject inventoryScreen;

    private InventorySlot[] slots;


    private void Start()
    {
        inventory = Inventory.instance;
        inventory.OnItemChangeCallback += UpdateUI;
        
    }

    public void inventoryOnOff() 
    {
        inventoryScreen.SetActive (!inventoryScreen.activeSelf);
        Debug.Log("called");
    }

    private void UpdateUI() 
    {
        slots = ItemsParent.GetComponentsInChildren<InventorySlot>();
        
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
