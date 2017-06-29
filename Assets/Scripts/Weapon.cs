using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate;
    public GameObject projectile;
    public Transform firePoint;

    private float fireTimer;
	
	void Update ()
    {
        if (fireTimer < fireRate)
        {
            fireTimer += Time.deltaTime;
        }
	}

    public void AttemptFire(Vector3 direction)
    {
        if (fireTimer >= fireRate)
        {
            GameObject newProjectile = Instantiate(projectile, firePoint.position, Quaternion.identity);
            newProjectile.GetComponent<Projectile>().SetVelocity(direction);
            Physics.IgnoreCollision(newProjectile.GetComponent<Collider>(), gameObject.GetComponent<Collider>());

            if (gameObject.tag == "Enemy")
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

                foreach (GameObject enemy in enemies)
                {
                    Physics.IgnoreCollision(newProjectile.GetComponent<Collider>(), enemy.GetComponent<Collider>());
                }
            }
            
            fireTimer = 0;
        }
    }
}
