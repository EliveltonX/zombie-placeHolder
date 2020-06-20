using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int space = 10;

    public List<Item> items = new List<Item>();


    #region Singleton

    public static Inventory instance;

    public void Awake()
    {
        if (instance != null) 
        {
            Debug.LogWarning("Mais de um inventario na Scene");
            return;
        }
        instance = this;
    }
    #endregion


    public delegate void OnItemChange();
    public OnItemChange OnItemChangeCallback;

    public bool Add(Item _newItem) 
    {
        if (items.Count >= space) 
        {
            Debug.Log("Não há vagas!");
            return false;
        }
        
        items.Add(_newItem);

        if (OnItemChangeCallback != null)
        {
            OnItemChangeCallback.Invoke();
        }

        return true;
    }
    public void Remove(Item _itemToRemove) 
    {
        items.Remove(_itemToRemove);

        if (OnItemChangeCallback != null)
        {
            OnItemChangeCallback.Invoke();
        }
    }
}
