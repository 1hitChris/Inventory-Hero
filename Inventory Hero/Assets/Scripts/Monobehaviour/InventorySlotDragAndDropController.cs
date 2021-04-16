using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotDragAndDropController : MonoBehaviour, IDropHandler
{
public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
       // eventData.pointerDrag.GetComponent<DragDrop>().droppedOnSlot = true;
       // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
    }
}
