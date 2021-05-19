using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawns
{
    //Item to be spawned
    Rigidbody itemSpawned { get; set; }
    //What material/the look of the item
    Renderer itemMaterial { get; set; }
    //Get item type
    ItemPickUp itemType { get; set; }

    void CreateSpawn();
}
