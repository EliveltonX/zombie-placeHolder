using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    private RectTransform objTrans;
    private CanvasGroup canvasGroup;
    private Text qtdUI;

    public Canvas canvas;
    public int quantidade =1;
    public ItemBase item = null;
    public Transform myParent; 

    private void Awake()
    {
        qtdUI = GetComponentInChildren<Text>();
        objTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        myParent = transform.parent;
        canvas = FindObjectOfType<Canvas>();
        updateUI();

       

        if (myParent!= null) 
        {
            GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .5f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.SetParent(canvas.transform);
        objTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) { return; }
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (transform.parent.GetComponent<ItemSlot>() == null) 
        {
            transform.SetParent(myParent);
            GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
    }

    public void updateUI()
    {
        if (quantidade < 2)
        {
            qtdUI.enabled = (false);
        }
        else
        {
            qtdUI.enabled = (true);
        }

        qtdUI.text = quantidade.ToString();
    }
}
