using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemController : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public Transform parent;
    public int yPos = 1300;
    
    public void Start()
    {
        parent = parent.GetComponent<Transform>();
        parent.transform.SetParent(GameObject.Find("Inventory Items").transform);
    }
    public void OnClick()
    {

    }

    public void AddRandomItem()
    {
        Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], new Vector3(transform.position.x, transform.position.y + yPos, 0), transform.rotation, parent);
    }
}