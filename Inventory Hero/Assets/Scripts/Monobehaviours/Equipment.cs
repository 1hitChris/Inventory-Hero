using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : ItemPickUp_SO
{
    public EquipmentSlot equipSlot;

    public int armorModifier;
    public int damageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveItemFromInventory();
    }
}

/*public enum ItemTypeDefinitions
{
    HEALTH,
    WEALTH,
    MANA,
    WEAPON,
    ARMOR,
    BUFF,
    EMPTY,
}*/

public enum EquipmentSlot
{
    HELMET,
    CHEST,
    SHOULDER,
    GLOVES,
    BELT,
    LEGS,
    BOOTS,
    NECK,
    RING,
}

