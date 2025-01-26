using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEvent : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    public Action<PointerEventData> dragEvent;
    public Action<PointerEventData> clickEvent;
    public enum UIMode
    {
        Click,
        Drag,
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(dragEvent != null)
            dragEvent.Invoke(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickEvent != null)
            clickEvent.Invoke(eventData);
    }

    
}
