
using UnityEngine;

[CreateAssetMenu(fileName ="New Equipament", menuName = "Inventory/Equipament")]
public class Equipament : Item
{
    public EquipType type = EquipType.Helmet;
    public int mod_armor;
    public SkinnedMeshRenderer mesh;
    public EquipmentMeshRegion[] coveredByMesh;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }

}
public enum EquipType 
{
    //Cloths
Feet,Pants,Shirt,
    //Armour
Helmet,Chest,Gloves,
    //Weapons
Melee,Gun,Trowable,
    //Other
BackPack
};
public enum EquipmentMeshRegion {Legs,Chest }; // corresponds to blendShapes;
