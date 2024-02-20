using System.Collections;
using System.Collections.Generic;
using Inventory.ObserverArray;
using UnityEngine;
using System;
[System.Serializable]
public class InventoryModel
{
    [SerializeField] private ObserverArray<ItemStack> _model;
    
    public event Action<ItemStack[]> OnModelChange
    {
        add => _model.OnArrayChange += value;
        remove => _model.OnArrayChange -= value;
    }

    public InventoryModel(int size)
    {
        this._model = new ObserverArray<ItemStack>(size);
    }

    public ItemStack GetItem(int index) => this._model.Get(index);

    public void Swap(int source, int target) => this._model.Swap(source, target);

    public bool AddItem(ItemStack item) => this._model.TryAdd(item);

    public void RemoveItem(ItemStack item) => this._model.TryRemove(item);

    public ItemStack[] GetContainer() => this._model.GetContainer();

    public void Clear() => this._model.Clear();

    public void Invoke() => this._model.Invoke();

    public bool CombileItem(int source, int target)
    {
        if (_model[target] == null) return false;
        if (_model[target].GetItem().GetName() != _model[source].GetItem().GetName()) return false;

        if (_model[target].CanAddTo(_model[source].GetStack()))
        {
            _model[target].AddStack(_model[source].GetStack());
            RemoveItem(_model[source]);
            Debug.Log("Combile");
            return true;
        }

        return false;
    }

}
