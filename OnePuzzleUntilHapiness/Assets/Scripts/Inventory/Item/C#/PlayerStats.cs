using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(Equipament _newItem, Equipament _oldItem)
    {
        if (_newItem != null)
        {
            armor.AddModfier(_newItem.mod_armor);
        }
        if (_oldItem != null) 
        {
            armor.RemoveModifier(_oldItem.mod_armor);
        }
    }
}
