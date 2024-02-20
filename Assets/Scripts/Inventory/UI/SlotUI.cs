using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;
public class SlotUI : SlotView, IPointerDownHandler, IDragHandler, IDropHandler, IEndDragHandler
{
    // event drop slot
    public event Action<SlotUI, SlotUI> OnDropSlot = delegate { };
    protected bool _isDrag;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_isDrag)
        {
            _isDrag = true;
            SetParent(this.transform.root);
            SetIconPosition(eventData.position);
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_isDrag)
        {
            SetIconPosition(eventData.position);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        _isDrag = false;
        SlotUI source = eventData.pointerDrag.GetComponent<SlotUI>();
        SlotUI target = this;

        if (source != null && target != null)
        {
            OnDropSlot?.Invoke(source, target);
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        SetParent(this.transform);
        RestartRectTranformIcon();
        _isDrag = false;
    }


    private void SetParent(Transform parent)
    {
        _icon.transform.SetParent(parent);
        _stack.transform.SetParent(parent);
        _icon.transform.SetAsLastSibling();
        _stack.transform.SetAsLastSibling();
    }

    private void SetIconPosition(Vector2 position)
    {
        _icon.transform.position = position;
        _stack.transform.position = position;
    }

    private void RestartRectTranformIcon()
    {
        _icon.rectTransform.localPosition = new Vector3(0, 0, 0);
        _stack.rectTransform.localPosition = new Vector3(0, 0, 0);
    }

}
