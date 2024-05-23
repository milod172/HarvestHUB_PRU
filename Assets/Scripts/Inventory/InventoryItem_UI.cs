using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem_UI : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] TextMeshProUGUI quantity;
    [SerializeField] private Image borderImage;
    public event Action<InventoryItem_UI> OnItemClick, OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag, OnRightMouseButtonClick;
    private bool empty = true;

    private void Awake()
    {
        ResetData();
        Deselect();
    }

    public void ResetData()
    {
        this.itemImage.gameObject.SetActive(false);
        empty = true;
    }

    public void Deselect()
    {
        borderImage.enabled = false;
    }

    public void SetData(Sprite sprite, int quantity)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        this.quantity.text = quantity + "";
        empty = false;
    }

    public void Select()
    {
        borderImage.enabled = true;
    }

    public void OnBeginDrag()
    {
        if (empty)
            return;
        OnItemBeginDrag?.Invoke(this);
    }

    public void Drop()
    {
        OnItemDroppedOn?.Invoke(this);
    }

    public void OnEndDrag()
    {
        OnItemEndDrag?.Invoke(this);
    }

    public void OnPointerClick(BaseEventData Data)
    {
        if(empty)
            return;
        Select();
        PointerEventData pointerData = (PointerEventData)Data;
        if (pointerData.button == PointerEventData.InputButton.Right)
            OnRightMouseButtonClick?.Invoke(this);
        else
            OnItemClick?.Invoke(this);
    }
}
