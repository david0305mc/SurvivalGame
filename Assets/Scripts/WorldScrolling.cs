using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScrolling : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float tileSize = 20f;

    [SerializeField] int terrainTileHorizontalCount;
    [SerializeField] int terrainTileVerticalCount;

    [SerializeField] private Vector2Int playerTilePosition;
    [SerializeField] int fieldOfVisionHeight = 3;
    [SerializeField] int fieldOfVisionWidth = 3;

    private Vector2Int currentTilePosition = new Vector2Int(0, 0);
    Vector2Int onTileGridPlayerPosition;
    private GameObject[,] terrainTiles;

    public void Add(GameObject gameObject, Vector2Int tilePosition)
    {
        terrainTiles[tilePosition. x, tilePosition.y] = gameObject;
    }

    private void Start()
    {
        UpdateTilesOnScreen();
    }

    private void Update()
    {
        playerTilePosition.x = (int)(playerTransform.position.x / tileSize);
        playerTilePosition.y = (int)(playerTransform.position.y / tileSize);

        playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0;
        playerTilePosition.y -= playerTransform.position.y < 0 ? 1 : 0;

        if (currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;
            onTileGridPlayerPosition.x = CalcPositionOnAxis(onTileGridPlayerPosition.x, true);
            onTileGridPlayerPosition.y  = CalcPositionOnAxis(onTileGridPlayerPosition.y, false);
            UpdateTilesOnScreen();
        }
    }

    private void UpdateTilesOnScreen()
    {
        for (int pov_x = -(fieldOfVisionWidth); pov_x < fieldOfVisionWidth / 2; pov_x++)
        {
            for (int pov_y = -(fieldOfVisionHeight / 2); pov_y < fieldOfVisionHeight / 2; pov_y++)
            {
                int tileToUpdate_x = CalcPositionOnAxis(playerTilePosition.x + pov_x, true);
                int tileToUpdate_y = CalcPositionOnAxis(playerTilePosition.y + pov_y, false);

                Debug.Log("TileToUpdate_x" + tileToUpdate_x + " tileToUpdate_y" + tileToUpdate_y);
                GameObject tile = terrainTiles[tileToUpdate_x, tileToUpdate_y];
                tile.transform.position = CalcTilePosition(
                    playerTilePosition.x + pov_x, 
                    playerTilePosition.y + pov_y);
            }
        }
    }

    private Vector3 CalcTilePosition(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize, 0f);
    }

    private int CalcPositionOnAxis(float currentValue, bool horizontal)
    {
        if (horizontal)
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileHorizontalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileHorizontalCount  - 1 + currentValue % terrainTileHorizontalCount;
            }
        }
        else
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terrainTileVerticalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTileVerticalCount -1 + currentValue % terrainTileVerticalCount;
            }
        }
        return (int)currentValue;
    }

    private void Awake()
    {
        terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];
    }
}
