using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO:: increment score when update removes dead enemy

public class Territory : MonoBehaviour {

    // enemy type
    public GameObject enemy;

    // spawnnode
    // this is for spawning enemies at certain locations
    // not working yet
    public GameObject spawnnode;

    // how many enemies to spawn
    public int enemyAmount;

    List<GameObject> enemies;

    // Use this for initialization
    void Start () {

        // create new list
        enemies = new List<GameObject>();

        // spawn enemies and add them to list
        for (int i = 0; i < enemyAmount; i++)
        {
            GameObject enemyClone = (GameObject)Instantiate(enemy, transform.position, transform.rotation);
            enemies.Add(enemyClone);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // loop through enemies
        for (int i = 0; i < enemies.Count; i++)
        {
            // if the enemy is dead
            //if(enemies[i].Dead)
            {
                // destroy enemy
                Destroy(enemies[i]);
                // remove from list
                enemies.RemoveAt(i);
                // increment score
            }
        }
    }
}