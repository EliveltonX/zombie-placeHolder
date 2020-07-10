using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler   
{
    public SlotType slotType = SlotType.Default;
    public DragAndDrop content;


    public void Awake()
    {
        if (GetComponentInChildren<DragAndDrop>()) 
        {
            content = GetComponentInChildren<DragAndDrop>();
        }
        
    }

    public void OnDrop(PointerEventData eventData) // quando user solta algun item encima deste
    {
        if (eventData.pointerDrag != null)//se realmente tem um obj e ele tem component DragAndDrop
        {
            ItemSlot onDragParent = eventData.pointerDrag.GetComponent<DragAndDrop>().myParent.GetComponent<ItemSlot>();
            Tratamento(eventData.pointerDrag.GetComponent<DragAndDrop>());

            //devo atualizar os equipamentos?
            if (slotType != SlotType.Default || onDragParent.slotType != default)
            {
                Inventory.instance.OnEquipChangedCallback.Invoke();
            }
            //update inventory!
            Inventory.instance.OnInvChangedCallback.Invoke();
        }
       
    }
  

    public virtual void Tratamento(DragAndDrop _ondrag)
    {
        ItemSlot onDragParent = _ondrag.myParent.GetComponent<ItemSlot>();

       

        if (content == null)//slot vazio
        {
            if (isCompatible(_ondrag))
            {
                //simplesmente colocar o item neste slot
                _ondrag.myParent.GetComponent<ItemSlot>().ClearSlot();
                AddNewObj(_ondrag);
                return;
            }
            else 
            {
                //retornar o item para slot de origem
                returnItemToLastSlot(_ondrag);
                return;
            }

        }
        if (content != null) //slot nao esta vazio
        {
            if (_ondrag.item.name == content.item.name) //items iguais
            {
                if (_ondrag.quantidade + content.quantidade <= content.item.stackAmount)// soma < stack 
                {
                    content.quantidade += _ondrag.quantidade;
                    _ondrag.myParent.GetComponent<ItemSlot>().ClearSlot();
                    Destroy(_ondrag.gameObject);
                    content.updateUI();
                }
                else //soma > stack
                {
                    _ondrag.quantidade -= (content.item.stackAmount - content.quantidade);
                    content.quantidade = content.item.stackAmount;
                    content.updateUI();
                    returnItemToLastSlot(_ondrag);
                    
                }
            return; 
            }

            if (isCompatible(_ondrag) && onDragParent.isCompatible(content))//slots compativeis //items diferentes
            {
                _ondrag.myParent.GetComponent<ItemSlot>().AddNewObj(content);
                AddNewObj(_ondrag);
            return;
            }
        }
    }

    public void AddNewObj(DragAndDrop _obj) //adiciona o item a este slot
    {
        content = _obj;
        _obj.transform.SetParent(transform);
        _obj.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        _obj.myParent = transform;
    }

    public void returnItemToLastSlot(DragAndDrop _item) 
    {
        _item.updateUI();
        _item.transform.SetParent(_item.myParent);
        _item.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }

    public void ClearSlot() 
    {
        content = null;
    }

    public bool isCompatible(DragAndDrop _item)
    {
        if (slotType == SlotType.Default || _item.item.slotType == slotType)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

}

public enum SlotType // define qual tipo de item pode ir em qual slot
{ 
    Default,    // default são slots que aceitao qlq tipo
    Helmet,
    Pants,
    Shirt,
    ChestRig,
    Shoes,
    Weapon
};
