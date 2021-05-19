using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotDragAndDropController : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image image;

    private void Start()
    {
        image.GetComponent<Image>();
        image.color = new Color32(125, 90, 50, 100);
    }

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<InventoryItemDragAndDropController>().droppedOnSlot = true;
        eventData.pointerDrag.GetComponent<RectTransform>().transform.position = GetComponent<RectTransform>().transform.position;
    }
    //When mouse pointer enters the slots boundary it changes colors
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color32(175, 130, 90, 100);
    }
    //When mouse pointer enters the slots boundary it changes back to original color
    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color32(125, 90, 50, 100);
    }


}
