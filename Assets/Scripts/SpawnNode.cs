using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNode : MonoBehaviour {

    // enemy type
    public GameObject enemy;

    // list of enemies
    List<GameObject> enemies;

    // how many enemies to spawn
    public int enemyAmount;

    // Use this for initialization
    void Start () {

        // create new list of enemies
        enemies = new List<GameObject>();

        // spawn enemies and add them to list
        for (int i = 0; i < enemyAmount; i++)
        {
            GameObject enemyClone = (GameObject)Instantiate(enemy, transform.position, transform.rotation);
            enemies.Add(enemyClone);
        }
    }
	
	// Update is called once per frame
	void Update () {
        // loop through enemies
        for (int i = 0; i < enemies.Count; i++)
        {
            //GetComponent<Enemy>();
            // if the enemy is dead
            if (enemies[i].GetComponent<Enemy>().GetIsDead())
            {
                DestroyEnemyAt(i);
            }
        }
    }

    void DestroyEnemyAt(int index)
    {
        // destroy enemy
        Destroy(enemies[index]);
        // remove from list
        enemies.RemoveAt(index);
    }

    List<GameObject> GetEnemies()
    {
        return enemies;
    }
}
