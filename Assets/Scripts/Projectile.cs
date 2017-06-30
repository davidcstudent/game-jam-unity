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
    private bool isAlive = true;

	void Start ()
    {

	}

	void Update ()
    {
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
                if (!playerOwned && isAlive)
                {
                    other.GetComponent<Player>().AdjustHealth(-damage);
                    isAlive = false;
                    Destroy(gameObject);
                    // get UI to show damage indicator
                    UI[] UIvar = Object.FindObjectsOfType(typeof(UI)) as UI[];
                    UIvar[0].GetComponent<UI>().DamageIndicator(this, other);
                }
                break;
            case "Enemy":
                if (playerOwned && isAlive)
                {
                    other.GetComponent<Enemy>().AdjustHealth(-damage);
                    isAlive = false;
                    Destroy(gameObject);
                }
                break;
            default:
                Destroy(gameObject);
                break;
        }        
    }

    public void SetVelocity(Vector3 direction)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = direction.normalized * speed;

        transform.forward = rigidbody.velocity;
    }
}
