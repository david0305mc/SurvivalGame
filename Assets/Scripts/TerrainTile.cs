using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTile : MonoBehaviour
{
    [SerializeField] private Vector2Int tilePosition;

    private void Start()
    {
        GetComponentInParent<WorldScrolling>().Add(gameObject, tilePosition);
        transform.position = new Vector3(-100, -100, 0);
    }
}
