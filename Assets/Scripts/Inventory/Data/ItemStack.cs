using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemStack
{
    private Item _item;
    private int _stack;

    #region constructor
    public ItemStack()
    {
        this._item = null;
        this._stack = 0;
    }

    public ItemStack(Item item, int stack)
    {
        this._item = item;
        this._stack = stack;
    }

    #endregion

    public Item GetItem()
    {
        return this._item;
    }

    public int GetStack()
    {
        return this._stack;
    }

    public int GetStackAvailable()
    {
        return this._item.GetMaxStack() - this._stack;
    }

    public void AddStack(int stack)
    {
        this._stack += stack;
    }

    public bool CanAddTo(int stackToAdd)
    {
        return GetStackAvailable() >= stackToAdd;
    }



}
