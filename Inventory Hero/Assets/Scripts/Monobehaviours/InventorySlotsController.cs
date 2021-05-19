using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotsController : MonoBehaviour
{
    [SerializeField] private int rows = 5;
    [SerializeField] private int columns = 5;
    [SerializeField] private float tileSize = 1;

    

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("InventorySlot"));

        //Creating the grid, changes depending on how big you want the rows and column
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                GameObject tile = (GameObject)Instantiate(referenceTile, transform);

                float posX = column * tileSize;
                float posY = row * -tileSize;

                tile.transform.position = new Vector3(posX, posY, 0);
            }
        }

        
        //Destroys the reference since it won't be needed anymore
        Destroy(referenceTile);
        
    }
   
}
