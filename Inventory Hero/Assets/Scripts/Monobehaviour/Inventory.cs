using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public int width;
    public int height;


    public void AddItem(Item item)
    {

    }

    public bool IsPlacementValid(Vector2Int position, Item item)
    {
        return true;
    }
    
    public void MoveItemPlacement(ItemPlacement itemPlacement, Vector2Int gridPosition)
    {

    }

    private void FindEmptySlot(int width, int height)
    {

    }
}
