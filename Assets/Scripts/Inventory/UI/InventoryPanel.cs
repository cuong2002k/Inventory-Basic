using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.ObserverArray;
using UnityEngine.EventSystems;

[System.Serializable]
public class InventoryPanel
{
    public GameObject SlotUIPrefabs;
    public List<SlotUI> SlotUIContainer;

    [SerializeField] private ItemStack _itemClick;


    public InventoryPanel(int size)
    {
        this.SlotUIContainer = new List<SlotUI>(size);
        SlotUIPrefabs = Resources.Load<GameObject>("SlotUI");
    }

    public void RefestUI(ItemStack[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            SlotUIContainer[i].SetItem(items[i]);
        }

        Debug.Log("Refest UI");
    }



}
