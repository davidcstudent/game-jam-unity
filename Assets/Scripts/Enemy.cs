using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed;
    public float minDistanceToPlayer;
    public float maxDistanceToPlayer;
    public float maxFireRange;
    
    private GameObject target;
    private Weapon weapon;
    private bool isDead;

	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        weapon = GetComponent<Weapon>();
	}
	
	void Update ()
    {
        Vector3 currentPosition = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 targetPosition = new Vector3(target.transform.position.x, 0, target.transform.position.z);

        if (Vector3.Distance(currentPosition, targetPosition) >= maxDistanceToPlayer)
        {
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, movementSpeed * Time.deltaTime);
        }
        else if (Vector3.Distance(currentPosition, targetPosition) <= minDistanceToPlayer)
        {
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, -movementSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(currentPosition, targetPosition) < maxFireRange)
        {
            weapon.AttemptFire(targetPosition - currentPosition);
        }
    }

    public bool GetIsDead()
    {
        return isDead;
    }
}
