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
                if (!playerOwned)
                {
                    other.GetComponent<Player>().AdjustHealth(-damage);
                    // get UI to show damage indicator
                    UI[] UIvar = Object.FindObjectsOfType(typeof(UI)) as UI[];
                    UIvar[0].GetComponent<UI>().DamageIndicator(this, other);

                    Destroy(gameObject);
                }
                break;
            case "Enemy":
                if (playerOwned)
                {
                    other.GetComponent<Enemy>().AdjustHealth(-damage);
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
