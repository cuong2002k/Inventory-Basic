using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
namespace Inventory.ObserverArray
{
    public interface IObserverArray<T>
    {
        public T Get(int index);
        public void Swap(int index1, int index2);
        public bool TryAdd(T item);
        public bool TryRemove(T item);
        public void Clear();
    }

    [Serializable]
    public class ObserverArray<T> : IObserverArray<T>
    {
        private T[] _items;
        private int _size;

        public T this[int index] => this._items[index];

        // event is called when the array changes
        public event Action<T[]> OnArrayChange = delegate { };

        public ObserverArray(int size)
        {
            this._size = size;
            _items = new T[this._size];
        }

        public T Get(int index)
        {
            return _items[index];
        }

        public void Swap(int index1, int index2)
        {
            (_items[index1], _items[index2]) =
            (_items[index2], _items[index1]);
            Invoke();
        }

        public bool TryAdd(T item)
        {
            for (int i = 0; i < this._size; i++)
            {
                if (this._items[i] != null) continue;
                this._items[i] = item;
                Invoke();
                return true;
            }
            return false;
        }

        public bool TryRemove(T item)
        {
            for (int i = 0; i < this._size; i++)
            {
                if (this._items[i] != null)
                {
                    if (EqualityComparer<T>.Default.Equals(_items[i], item))
                    {
                        _items[i] = default;
                        Invoke();
                        return true;
                    }
                }
            }
            return false;
        }

        // invoke event
        public void Invoke() => OnArrayChange?.Invoke(_items);

        public T[] GetContainer() => _items;

        public void Clear()
        {
            this._items = new T[this._items.Length];
            Invoke();
        }
    }

}
