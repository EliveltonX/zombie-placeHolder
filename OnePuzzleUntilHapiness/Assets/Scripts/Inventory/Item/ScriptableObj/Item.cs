using UnityEngine;

[CreateAssetMenu (fileName = "Item", menuName ="Inventory/item")]
public class Item : ScriptableObject
{

    public string itemName = "New Item";
    public string description = "Um novo item fresquinho, Direto do forno :) ";
    public Sprite icon = null;

    public virtual void Use() 
    {
        Debug.Log("Use this item");
    
    }
    public void RemoveFromInventory() 
    {
        Inventory.instance.Remove(this);
    }
}
