using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float movementDistance;
    public float cameraSpeedHorizontal = 2.0f;
    public float cameraSpeedVertical = 2.0f;
    public int maxHealth;
    public float DodgeRate = 2.0f;
    public float DodgeDistance = 25.0f;
    public GameObject cameraRotator;

    private int currentHealth;
    private float yaw = 0;
    private float pitch = 0;
    private Weapon currentWeapon;
    private float DodgeTimer;

    private int score = 0;

    // Use this for initialization
    void Start ()
    {
        currentHealth = maxHealth;
        currentWeapon = GetComponent<Weapon>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currentHealth <= 0)
        {
            GameObject.Find("Game Controller").GetComponent<GameController>().gameOver = true;
        }

        // WASD input
        // ---------------------------------------------------
        // Forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * movementDistance;
        }
        // Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * movementDistance;
        }
        // Down
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * movementDistance;
        }
        // Right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * movementDistance;
        }
        // ---------------------------------------------------

        // dodge
        // ---------------------------------------------------
        checkDodge();
        // ---------------------------------------------------

        // Aim with mouse
        yaw += cameraSpeedHorizontal * Input.GetAxis("Mouse X");
        pitch -= cameraSpeedVertical * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        cameraRotator.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        // Firing weapon
        if (Input.GetMouseButton(0))
        {
            currentWeapon.AttemptFire(cameraRotator.transform.forward);
        }
    }

    public void AdjustHealth(int amount)
    {
        currentHealth += amount;
    }

    void checkDodge()
    // ---------------------------------------------------
    {
        if (DodgeTimer < DodgeRate)
        {
            DodgeTimer += Time.deltaTime;
        }

        if (DodgeTimer >= DodgeRate)
        {
            // Dodge Left
            if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.A) ||
                Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.LeftControl))
            {
                transform.position -= (transform.right) * movementDistance * (Time.deltaTime * DodgeDistance);
                DodgeTimer = 0;
            }
            // Dodge Right
            if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.D) ||
                Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftControl))
            {
                transform.position += (transform.right) * movementDistance * (Time.deltaTime * DodgeDistance);
                DodgeTimer = 0;
            }
        }
    }
    // ---------------------------------------------------

    public float getHealthPercent()
    {
        return currentHealth / (float)maxHealth;
    }

    public int getScore()
    {
        return score;
    }

    public void incrementScore()
    {
        score++;
    }
}