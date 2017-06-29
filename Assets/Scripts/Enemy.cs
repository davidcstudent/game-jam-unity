using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed;
    public float minDistanceToPlayer;
    public float maxDistanceToPlayer;

    private GameObject target;

	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");
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
    }
}
