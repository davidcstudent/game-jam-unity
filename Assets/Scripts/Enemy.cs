﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed;
    public float minDistanceToPlayer;
    public float maxDistanceToPlayer;
    public float maxFireRange;
    public int maxHealth;
    public MeshRenderer meshRenderer;

    private int currentHealth;
    private GameObject target;
    private Weapon weapon;
    private bool isDead = false;
    private CharacterController controller;

	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        weapon = GetComponent<Weapon>();
        controller = GetComponent<CharacterController>();
        currentHealth = maxHealth;

        controller.detectCollisions = false;
    }
	
	void Update ()
    {
        if (meshRenderer.material.color.r > 1)
        {
            meshRenderer.material.color += new Color(-1f, 0, 0);
        }

        if (meshRenderer.material.color.g < 1)
        {
            meshRenderer.material.color += new Color(0, 0.1f, 0);
        }

        if (meshRenderer.material.color.b < 1)
        {
            meshRenderer.material.color += new Color(0, 0, 0.1f);
        }

        if (currentHealth <= 0)
        {
            isDead = true;
        }

        Vector3 currentPosition = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 targetPosition = new Vector3(target.transform.position.x, 0, target.transform.position.z);

        Vector3 direction = (targetPosition - currentPosition).normalized;

        if (Vector3.Distance(currentPosition, targetPosition) >= maxDistanceToPlayer)
        {
            controller.Move(direction * movementSpeed * Time.deltaTime);
            //transform.position = Vector3.MoveTowards(currentPosition, targetPosition, movementSpeed * Time.deltaTime);
        }
        else if (Vector3.Distance(currentPosition, targetPosition) <= minDistanceToPlayer)
        {
            controller.Move(direction * -movementSpeed * Time.deltaTime);
            //transform.position = Vector3.MoveTowards(currentPosition, targetPosition, -movementSpeed * Time.deltaTime);
        }
        else
        {
            weapon.AttemptFire(targetPosition - currentPosition);
        }

        // set rotation
        // ---------------------------------------------------
        this.transform.rotation = 
            Quaternion.LookRotation(
                (targetPosition - transform.position).normalized);
        // ---------------------------------------------------


    }

    public bool GetIsDead()
    {
        return isDead;
    }

    public void AdjustHealth(int amount)
    {
        meshRenderer.material.color = new Color(10, 0, 0);

        currentHealth += amount;
    }
}
