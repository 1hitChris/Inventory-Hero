using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = ("New Item"), menuName = ("New Item"), order = 1)]
public class ItemPickUp_SO : ScriptableObject
{
    public string itemName = "New Item";
    /*public int itemAmount = 0;
    public int spawnChanceWeight = 0;

    public Material itemMaterial = null;

    public bool isEquipped = false;
    public bool isInteractable = false;
    public bool isStorable = false;
    public bool isUnique = false;
    public bool isIndestructable = false;
    public bool isQuestItem = false;
    public bool isStackable = false;
    public bool destroyOnUse = false;
    public float itemWeight = 0f;

    public Rigidbody itemSpawnObject = null;
    public Rigidbody weaponSlotObject = null;
    */
    public virtual void Use()
    {
        // Use item
        // Something might happen

        Debug.Log("Using " + name);
    }

    public void RemoveItemFromInventory()
    {
        Inventory.instance.Remove(this);
    }

    public Sprite itemIcon = null;
}
