using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public ItemPickUp_SO item;


    public override void Interact()
    {
        base.Interact();
    }

    /* private void OnTriggerStay2D(Collider2D collision)
     {
         if (Input.GetKeyDown(KeyCode.Z))
         {
             bool wasPickedUp = Inventory.instance.Add(item);

             if (wasPickedUp)
             {
                 Debug.Log(item.name + " pick up!");

                 Destroy(gameObject);
             }
         }
     }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
        {
            Debug.Log(item.name + " pick up!");

            Destroy(gameObject);
        }
    }
}
