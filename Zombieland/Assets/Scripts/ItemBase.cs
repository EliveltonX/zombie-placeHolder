using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Item",menuName ="Inventory/Item")]
public class ItemBase : ScriptableObject
{
    public string itemName = "NewItem";
    public string description = "Descrição deste item  :)";
    public int stackAmount = 1;
    public Sprite icon = null;
    public SlotType slotType = SlotType.Default;
    

    public virtual void Use() 
    {
        Debug.Log("Using item, mas nao foi implementado, use apenas Override");
    }
    public virtual void SetStats() 
    {
        Debug.Log("Equip item, mas nao foi implementado, use apenas Override");
    }
    public virtual void RemoveStats() 
    {
        Debug.Log("Equip item, mas nao foi implementado, use apenas Override");
    }
    public virtual SkinnedMeshRenderer getMesh() 
    {
        Debug.Log("Get Skinned mesh renderer nao foi implementado");
        return null;
    }
   
}
