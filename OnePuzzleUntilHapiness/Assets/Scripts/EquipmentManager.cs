using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion
    Equipament[] currentEquiped;
    SkinnedMeshRenderer[] currentMeshes;
    Inventory inventory = Inventory.instance;

    public delegate void OnEquipmentChanged(Equipament newItem, Equipament oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    public SkinnedMeshRenderer targetMesh;

    private void Start()
    {
       int numberOfSlots =  System.Enum.GetNames(typeof(EquipType)).Length;
        currentEquiped = new Equipament[numberOfSlots];
        currentMeshes = new SkinnedMeshRenderer[numberOfSlots];
    }

    public void Equip(Equipament newEquip) 
    {
        int slotIndex = (int)newEquip.type;
        Equipament oldItem = null;
        if (currentEquiped[slotIndex] != null) 
        {
            oldItem = currentEquiped[slotIndex];
            inventory.Add(oldItem);
        }
        currentEquiped[slotIndex] = newEquip;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newEquip.mesh);
        newMesh.transform.parent = targetMesh.transform;
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[slotIndex] = newMesh;
        SetEquipmentBlendShapes(newEquip, 100);

        if (onEquipmentChanged != null) 
        {
            onEquipmentChanged.Invoke(newEquip, oldItem);
        }
    }

    public void Unequip(int _slotIndex) 
    {
        if (currentEquiped[_slotIndex] != null) 
        {
            if (currentMeshes[_slotIndex] != null) 
            {
                Destroy(currentMeshes[_slotIndex].gameObject);
            }
            Equipament olditem = currentEquiped[_slotIndex];
            SetEquipmentBlendShapes(olditem, 0);
            inventory.Add(olditem);

            currentEquiped[_slotIndex] = null;
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, olditem);
            }
        }
    }

    public void UnequipAll() 
    {
        for (int i = 0; i < currentEquiped.Length; i++)
        {
            Unequip(i);
        }
    }

    void SetEquipmentBlendShapes(Equipament _equip, int _weight) 
    {
        foreach (EquipmentMeshRegion blendShape in _equip.coveredByMesh)
        {
            targetMesh.SetBlendShapeWeight((int)blendShape,_weight);
        }
    }


    public Equipament[] GetCurrentEquiped() 
    {
        return currentEquiped;
    }

}
