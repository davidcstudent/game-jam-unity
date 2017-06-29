﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// TODO:: increment score when update removes dead enemy

public class Territory : MonoBehaviour
{
    // array of spawners
    public SpawnNode[] spawnNodes;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        int enemiesLeft = 0;

        foreach (SpawnNode node in spawnNodes)
        {
            enemiesLeft += node.GetEnemies().Count;
        }

        Debug.Log("Enemies left: " + enemiesLeft);
    }
}