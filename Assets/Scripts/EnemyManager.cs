using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;

    [SerializeField] Transform player;

    float timer;
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();
        position += player.transform.position;

        var newEnemy = Instantiate(enemy).GetComponent<Enemy>();
        newEnemy.SetTarget(player);
        newEnemy.transform.position = position;
        newEnemy.transform.parent = transform;
    }

    private Vector3 GenerateRandomPosition()
    {
        
        Vector3 position = new Vector3();
        float f = UnityEngine.Random.value > 0.5f ? -1 : 1;

        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.x = spawnArea.x * f;
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
        }
        return position;
    }
}
