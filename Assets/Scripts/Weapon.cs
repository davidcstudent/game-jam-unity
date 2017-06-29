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

            Collider col1 = newProjectile.GetComponent<Collider>();
            Collider col2 = gameObject.GetComponent<Collider>();

            Physics.IgnoreCollision(newProjectile.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
            fireTimer = 0;
        }
    }
}
