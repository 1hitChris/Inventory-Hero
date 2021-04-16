using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/New Item", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;
    public int width;
    public int height;
    public int maxQuantity;
    public bool isStackable;
    public Item.Type itemType;
    public Item.Rarity itemRarity;
    public Item.Group itemGroup;

    public bool canRotate
    {
        get
        {
            return width != height;
        }

    }

    enum Type
    {
        Weapon,
        Shield,
        Chest,
        Gloves,
        Pants,
        Belt,
        Boots,
        Useable,
        Crafting,
    }

    enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }

    enum Group
    {
        Material,
        Equipment,
        QuestItem
    }
}
