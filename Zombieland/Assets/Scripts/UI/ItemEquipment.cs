using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Equipment", menuName = "Inventory/Equipment")]
public class ItemEquipment : ItemBase
{
    //public GameObject mesh;
    public int mod_health = 0;
    public int mod_armor = 0;
    public int mod_attack = 0;

    public SkinnedMeshRenderer mesh;

   
    public override void SetStats()
    {
        PlayerStats.instance.AddModifiers(mod_health,mod_armor,mod_attack);
    }
    public override void RemoveStats()
    {
        PlayerStats.instance.RemoveModifiers(mod_health, mod_armor, mod_attack);
    }
    public override SkinnedMeshRenderer getMesh()
    {
        return mesh;
    }

}
