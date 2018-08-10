﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Respawns killed enemies at the origin

public class EnemyRespawner : MonoBehaviour {

    public static EnemyRespawner instance;

    public GameObject enemyPrefab;
    public int respawnTime;

    private bool respawn;
    private float respawnEnemyCalledTime;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (respawn && Time.time - respawnEnemyCalledTime > respawnTime)
        {
            Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
            respawn = false;
        }
    }

    public void RespawnEnemy()
    {
        respawnEnemyCalledTime = Time.time;
        respawn = true;
    }
}
