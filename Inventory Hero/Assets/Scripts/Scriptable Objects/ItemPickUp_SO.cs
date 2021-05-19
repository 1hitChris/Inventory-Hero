using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypeDefinitions
{
    HEALTH,
    WEALTH,
    MANA,
    WEAPON,
    ARMOR,
    BUFF,
    EMPTY,
}

public enum ItemArmorSubType
{
    NONE,
    HELMET,
    CHEST,
    SHOULDER,
    GLOVES,
    BELT,
    LEGS,
    BOOTS,
}

[CreateAssetMenu(fileName = ("New Item"), menuName = ("New Item"), order = 1)]
public class ItemPickUp_SO : ScriptableObject
{
    public string itemName = "New Item";
    public ItemTypeDefinitions itemType = ItemTypeDefinitions.EMPTY;
    public ItemArmorSubType itemArmorSubType = ItemArmorSubType.NONE;
    public int itemAmount = 0;
    public int spawnChanceWeight = 0;

    public Material itemMaterial = null;
    public Sprite itemIcon = null;

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
}
