using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour, ISpawns
{
    public ItemPickUp_SO[] itemDefinitions;

    private int whichToSpawn = 0;
    private int totalSpawnWeight = 0;
    private int chosen = 0;

    public Transform parent;
    public int yPos = 1300;
    public int xPos = 1000;
    public Rigidbody itemSpawned { get; set; }
    public Renderer itemMaterial { get; set; }
    public ItemPickUp itemType { get; set; }
    public AudioSource clickSound;

    public void CreateSpawn()
    {
        clickSound.Play();
        foreach (ItemPickUp_SO ip in itemDefinitions)
        {
            whichToSpawn += ip.spawnChanceWeight;
            if (whichToSpawn >= chosen)
            {
                itemSpawned = Instantiate(ip.itemSpawnObject, new Vector3(transform.position.x + xPos, transform.position.y + yPos, 0), Quaternion.identity, parent);

                itemMaterial = itemSpawned.GetComponent<Renderer>();
                itemMaterial.material = ip.itemMaterial;

                itemType = itemSpawned.GetComponent<ItemPickUp>();
                itemType.itemDefinition = ip;
                break;
            }
        }
    }

    void Start()
    {
        clickSound = GetComponent<AudioSource>();
        parent = parent.GetComponent<Transform>();
        parent.transform.SetParent(GameObject.Find("Inventory Items").transform);

        foreach (ItemPickUp_SO ip in itemDefinitions)
        {
            totalSpawnWeight += ip.spawnChanceWeight;
        }
    }


}
