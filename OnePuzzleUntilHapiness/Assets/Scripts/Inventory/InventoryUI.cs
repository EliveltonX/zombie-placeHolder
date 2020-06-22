using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
   

    public Transform ItemsParent;
    public Transform equipmentSlotParent;
    public GameObject inventoryScreen,playerStatsScreen;

    private EquipmentManager equipManager;

    private InventorySlot[] slots;
    private EquipmentSlotUI[] equipSlots;


    private void Start()
    {
        equipManager = EquipmentManager.instance;

        inventory = Inventory.instance;
        inventory.OnItemChangeCallback += UpdateUI;
        
    }

    public void inventoryOnOff() 
    {
        inventoryScreen.SetActive (!inventoryScreen.activeSelf);
        playerStatsScreen.SetActive (inventoryScreen.activeSelf);
        //Debug.Log("called");
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

        UpdateEquipment();
    }
    public void UpdateEquipment()
    {
        equipSlots = equipmentSlotParent.GetComponentsInChildren<EquipmentSlotUI>();

        Equipament[] currentEquiped = equipManager.GetCurrentEquiped();

        for (int i = 0; i < currentEquiped.Length; i++)
        {
            if (currentEquiped[i] != null)
            {
                equipSlots[i].AddItem(currentEquiped[i]);
            }
            else 
            {
                equipSlots[i].ClearSlot();
            }
        }

    }
}
