using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat 
{
   [SerializeField]
    private int baseValue;

    private List<int> modifiers = new List<int>();

    public int getValue() 
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);

        return finalValue; ;
    }

    public void AddModfier(int _modifier) 
    {
        if (_modifier != 0) 
        {
            modifiers.Add(_modifier);
        }
        
    }
    public void RemoveModifier(int _modifier) 
    {
        if (_modifier != 0)
        {
            modifiers.Remove(_modifier);
        }
    }
}
