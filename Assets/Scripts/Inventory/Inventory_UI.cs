using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField]
    private InventoryItem_UI itemPrefab;
    [SerializeField]
    private RectTransform contentPanel;
    [SerializeField] InventoryDescription_UI itemDescription;

    List<InventoryItem_UI> listOfUIItems = new List<InventoryItem_UI>();

    public Sprite image;
    public int quantity;
    public string title, description;

    private void Awake()
    {
        Hide();
        itemDescription.ResetDescription();
    }

    public void InitializeInventory(int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            InventoryItem_UI uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            uiItem.transform.localScale = new Vector3(1, 1, 1);
            listOfUIItems.Add(uiItem);
            uiItem.OnItemClick += HandleItemSelection;
            uiItem.OnItemBeginDrag += HandleBeginDrag;
            uiItem.OnItemDroppedOn += HandleSwap;
            uiItem.OnItemEndDrag += HandleEndDrag;
            uiItem.OnRightMouseButtonClick += HandleShowItemActions;
        }
    }

    private void HandleShowItemActions(InventoryItem_UI uI)
    {
        throw new NotImplementedException();
    }

    private void HandleEndDrag(InventoryItem_UI uI)
    {

    }

    private void HandleSwap(InventoryItem_UI uI)
    {

    }

    private void HandleBeginDrag(InventoryItem_UI uI)
    {

    }

    private void HandleItemSelection(InventoryItem_UI uI)
    {
        Debug.Log("click");
        itemDescription.SetDescription(image, title, description);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        itemDescription.ResetDescription();
        listOfUIItems[0].SetData(image, quantity);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
