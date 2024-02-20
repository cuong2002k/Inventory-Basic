using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class SlotView : MonoBehaviour
{
    public int ID;
    public ItemStack Item;
    [SerializeField] protected Image _icon;
    [SerializeField] protected TextMeshProUGUI _stack;

    private void Start()
    {
        if (_icon == null) Debug.Log("ref icon is null");
        if (_stack == null) Debug.Log("ref stack is null");
    }

    public void SetItem(ItemStack item)
    {
        this.Item = item;
        SetUI();
    }

    public void SetUI()
    {
        if (Item == null)
        {
            SetDisplayUI(false);
        }
        else
        {
            SetDisplayUI(true);
            SetUIValue();
        }
    }

    public void SetDisplayUI(bool active)
    {
        if (_icon == null || _stack == null) return;
        _icon.gameObject.SetActive(active);
        _stack.gameObject.SetActive(active);
    }

    public void SetUIValue()
    {
        if (_icon == null || _stack == null) return;
        _icon.sprite = Item.GetItem().GetIcon();
        _stack.text = "" + Item.GetStack();
    }
}
