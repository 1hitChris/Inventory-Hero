using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    #region Singelton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
        }
        instance = this;
    }
    #endregion
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangeCallBack;

    public int space = 20;
    public bool inventoryFull;

    public List<ItemPickUp_SO> items = new List<ItemPickUp_SO>();

    private void Start()
    {
        inventoryFull = false;
    }

    public bool Add(ItemPickUp_SO item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room in the inventory!");
            inventoryFull = true;
            return false;
        }
        items.Add(item);

        if (onItemChangeCallBack != null)
        {
            onItemChangeCallBack.Invoke();
        }


        return true;
    }

    public void Remove(ItemPickUp_SO item)
    {
        items.Remove(item);

        inventoryFull = false;
        if (onItemChangeCallBack != null)
        {
            onItemChangeCallBack.Invoke();
        }
    }

    IEnumerator TextTimer()
    {
        yield return new WaitForSecondsRealtime(2);
    }
}
