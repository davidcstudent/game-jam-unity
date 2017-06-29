using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float maxLifeTime;
    public float speed;
    public int damage;
    public bool playerOwned;

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

    void OnTriggerEnter(Collider collider)
    {
        GameObject other = collider.gameObject;

        switch (other.tag)
        {
            case "Player":
                other.GetComponent<Player>().AdjustHealth(-damage);
                break;
            case "Enemy":
                other.GetComponent<Enemy>().AdjustHealth(-damage);
                break;
        }

        Destroy(gameObject);
    }

    public void SetVelocity(Vector3 direction)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = direction.normalized * speed;
    }
}
