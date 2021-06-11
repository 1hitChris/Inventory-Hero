using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public ItemPickUp_SO[] items;

    public int index;

    private void Start()
    {
        index = Random.Range(0, items.Length);
    }

    private void Update()
    {
        index = Random.Range(0, items.Length);
    }

    public void GetRandomItemFromArray(ItemPickUp_SO items)
    {
        Inventory.instance.Add(items);
    }
    public void SpawnRandomItem()
    {
        GetRandomItemFromArray(items[index]);
    }
}
