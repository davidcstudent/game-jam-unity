using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float maxLifeTime;
    public float damage;
    public float speed;

    private float currentLifeTime = 0;
    private Vector3 direction = new Vector3(0, 0, 0);

	void Start ()
    {
		
	}

	void Update ()
    {
        transform.position += direction * speed * Time.deltaTime;

        currentLifeTime += Time.deltaTime;

        if (currentLifeTime >= maxLifeTime)
        {
            Destroy(gameObject);
        }
	}

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction.normalized;
    }
}
