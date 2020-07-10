using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    private Inventory inventory;
    private List<ItemBase> currentEquiped = new List<ItemBase>();
    //private List<SkinnedMeshRenderer> currentMeshes = new List<SkinnedMeshRenderer>();
    private SkinnedMeshRenderer[] currentMeshes ; 

    public SkinnedMeshRenderer equipTarget;

    private void Start()
    {
        inventory = Inventory.instance;
        int NumSlots = System.Enum.GetNames(typeof(SlotType)).Length;
        currentMeshes = new SkinnedMeshRenderer[NumSlots];
    }


    public void EquipItems() 
    {
        
        List<ItemBase> newItems = inventory.GetEquipedItems();


        foreach (ItemBase item in currentEquiped)
        {
            item.RemoveStats();
            //currentEquiped.Remove(item);
            //Debug.Log("Item Removed");   
        }
        foreach (SkinnedMeshRenderer mesh in currentMeshes)
        {
            Destroy(mesh);
        }

        currentEquiped.Clear();

        foreach (ItemBase item in newItems)
        {
            item.SetStats();
            currentEquiped.Add(item);
            SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(item.getMesh());
            newMesh.transform.SetParent(equipTarget.transform);
            newMesh.bones = equipTarget.bones;
            newMesh.rootBone = equipTarget.rootBone;
            currentMeshes[(int)item.slotType] = newMesh;

            Debug.Log("Item inserted");
        }
    }
}
