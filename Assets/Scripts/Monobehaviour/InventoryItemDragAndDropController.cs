using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItemDragAndDropController : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector2 startingPosition;
    private bool droppedOnSlot;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
       /* eventData.pointerDrag.GetComponent<DragDrop>().droppedOnSlot = false;
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;*/
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
       // rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        /*canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (droppedOnSlot == false)
        {
            transform.position = defaultPos;
        }
        else
        {
            defaultPos = transform.position;
        }*/
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void DroppedOnSlotHappened()
    {

    }
}
