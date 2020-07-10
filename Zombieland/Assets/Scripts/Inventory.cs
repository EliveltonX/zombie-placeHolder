using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ItemBase> inventoryItems = new List<ItemBase>();
    private List<ItemBase> EquipedItems = new List<ItemBase>();

    public static Inventory instance; // singleton

    public Transform invParent = null;
    public Transform equipParent = null;
    public GameObject inventoryUI = null;

    public delegate void OnInventoryChanged();
    public delegate void OnEquipmentChanged();
    public OnInventoryChanged OnInvChangedCallback;
    public OnEquipmentChanged OnEquipChangedCallback;

    private Controles controles;

    public void Awake()
    {

        controles = new Controles();
        controles.PlayerControles.INVENTORY.performed += ctx => OpenCloseInventory();

        #region Singleton Test
        if (instance != null) 
        {
            Debug.Log("Mais de um Player Inventory na Scene");
            return;
        }
        instance = this;
        #endregion

        OnEquipChangedCallback += UpdateEquipment;
        OnInvChangedCallback += UpdateInventory;

    }

    private void UpdateInventory() 
    {
        inventoryItems.Clear();
        DragAndDrop[] allInvSlots = invParent.GetComponentsInChildren<DragAndDrop>();

        for (int i = 0; i < allInvSlots.Length; i++)
        {
            if (allInvSlots[i].item != null) 
            {
                AddToInventory(allInvSlots[i].item);
            }
        }
        

    }

    private void UpdateEquipment() 
    {
        EquipedItems.Clear();
        DragAndDrop[] allEquipSlots = equipParent.GetComponentsInChildren<DragAndDrop>();

        for (int i = 0; i < allEquipSlots.Length; i++)
        {
            if (allEquipSlots[i].item != null)
            {
                AddToEquipment(allEquipSlots[i].item);
            }
        }
        GetComponent<EquipmentManager>().EquipItems();
    }

    public void AddToInventory(ItemBase _item) 
    {
        inventoryItems.Add(_item);
    }
    public void AddToEquipment(ItemBase _item) 
    {
        EquipedItems.Add(_item);
    }
    public void removeFromInventory(ItemBase _item) 
    {
        inventoryItems.Remove(_item);
    }
    public void RemoveFromEquipment(ItemBase _item) 
    {
        EquipedItems.Remove(_item);
    }

    public void OpenCloseInventory() 
    {
        Debug.Log("Called");
        inventoryUI.SetActive(!inventoryUI.activeSelf);

    }

    public List<ItemBase> GetEquipedItems() 
    {
        return EquipedItems;
    }

    public void OnEnable()
    {
        controles.PlayerControles.Enable();
    }
    public void OnDisable()
    {
        controles.PlayerControles.Disable();
    }

}
