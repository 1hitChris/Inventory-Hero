using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotView : MonoBehaviour
{
    public Transform itemsParent;
    Inventory inventory;
    InventorySlotsController[] slots;

    public GameObject inventoryUI;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangeCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlotsController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }*/
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
