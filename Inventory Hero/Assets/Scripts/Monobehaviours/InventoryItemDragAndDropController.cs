using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemDragAndDropController : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] Image image;
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioClip dropSound;
    [SerializeField] new AudioSource audio;
    //public InventorySlotDragAndDropController itemSlotColor;

    public Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 defaultPos;
    public bool droppedOnSlot;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        //itemSlotColor = GetComponent<InventorySlotDragAndDropController>();
        //GameObject itemSlots = GameObject.Find("Inventory Slots");
        //itemSlotColor = itemSlots.GetComponentInChildren<InventorySlotDragAndDropController>();
        defaultPos = transform.position;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponent<Canvas>();
        GameObject canvasObject = GameObject.Find("InventoryUI");
        canvas = canvasObject.GetComponent<Canvas>();
    }

    //When drag begins it will change the alpha of the item and make it transparent
    public void OnBeginDrag(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<InventoryItemDragAndDropController>().droppedOnSlot = false;
        canvasGroup.alpha = .5f;
        canvasGroup.blocksRaycasts = false;
    }

    //When dragging the item will snap to the mousepointers position
    public void OnDrag(PointerEventData eventData)
    {
        image.transform.position = Input.mousePosition;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    //When dragging has ended the alpha will change back to its former state
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (droppedOnSlot == false)
        {
            transform.position = defaultPos;
        }
        else
        {
            defaultPos = transform.position;
        }
    }

    //Will play a sound when pointer is pressing the item
    public void OnPointerDown(PointerEventData eventData)
    {
        audio.PlayOneShot(clickSound, 1f);
        canvasGroup.alpha = .5f;
        canvasGroup.blocksRaycasts = false;
    }

    //Will play a sound when dropping item/when the pointer is up
    public void OnPointerUp(PointerEventData eventData)
    {
        audio.PlayOneShot(dropSound, 1f);
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}
