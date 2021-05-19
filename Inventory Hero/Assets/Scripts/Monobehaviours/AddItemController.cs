using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemController : MonoBehaviour
{
    //public InventorySlotsController[] itemSlots;
    public GameObject[] items;
    public AudioSource clickSound;

    public Transform parent;
    public int yPos = 1300;
    public int xPos = 1000;

    public void Start()
    {
        clickSound = GetComponent<AudioSource>();
        parent = parent.GetComponent<Transform>();
        parent.transform.SetParent(GameObject.Find("Inventory Items").transform);
    }
    public void OnClick()
    {

    }

    //Adds a random item at a specific position (Will be changed later to snap to empty slot space)
    public void AddItem()
    {
        clickSound.Play();
        Instantiate(items[Random.Range(0, items.Length)], new Vector3(transform.position.x + xPos, transform.position.y + yPos, 0), transform.rotation, parent);
    }
}