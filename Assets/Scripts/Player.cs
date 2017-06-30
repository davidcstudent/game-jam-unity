using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float movementDistance;
    public float WalkingSpeed = 1.0f;
    public float SprintingSpeed = 2.0f;
    public float cameraSpeedHorizontal = 2.0f;
    public float cameraSpeedVertical = 2.0f;
    public int maxHealth;
    public float DodgeRate = 2.0f;
    public float DodgeDistance = 25.0f;
    public float JumpHeight = 100.0f;
    public float energyLoss = 1.0f;
    public GameObject cameraRotator;
    public MeshRenderer meshRenderer;
    public Image hitMarker;

    private int currentHealth;
    private float movementSpeed;
    private float yaw = 0;
    private float pitch = 0;
    private Weapon currentWeapon;
    private float DodgeTimer;
    private CharacterController controller;

    private Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);

    private int score = 0;

    // Use this for initialization
    void Start ()
    {
        movementSpeed = WalkingSpeed;
        currentHealth = maxHealth;
        currentWeapon = GetComponent<Weapon>();
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
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
            GameObject.Find("Game Controller").GetComponent<GameController>().gameOver = true;
        }

        // sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = SprintingSpeed;
        }
        else
        {
            movementSpeed = WalkingSpeed;
        }

        // WASD input
        // ---------------------------------------------------
        // Forward
        if (Input.GetKey(KeyCode.W))
        {
            controller.Move(transform.forward * Time.deltaTime * movementDistance * movementSpeed);
        }
        // Left
        if (Input.GetKey(KeyCode.A))
        {
            controller.Move(-transform.right * Time.deltaTime * movementDistance * movementSpeed);
        }
        // Down
        if (Input.GetKey(KeyCode.S))
        {
            controller.Move(-transform.forward * Time.deltaTime * movementDistance * movementSpeed);
        }
        // Right
        if (Input.GetKey(KeyCode.D))
        {
            controller.Move(transform.right * Time.deltaTime * movementDistance * movementSpeed);
        }
        // ---------------------------------------------------

        // dodge
        // ---------------------------------------------------
        checkDodge();
        // ---------------------------------------------------

        // jump
        // ---------------------------------------------------
        jump();
        // ---------------------------------------------------

        // Aim with mouse
        yaw += cameraSpeedHorizontal * Input.GetAxis("Mouse X");
        pitch -= cameraSpeedVertical * Input.GetAxis("Mouse Y");

        if (pitch > 75f)
        {
            pitch = 75f;
        }
        if (pitch < -75f)
        {
            pitch = -75f;
        }

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
        if (amount < 0)
        {
            meshRenderer.material.color = new Color(10, 0, 0);
            hitMarker.color += new Color(0, 0, 0, 0.2f);
        }
        

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

    void jump()
    {
        // apply gravity
        transform.position -= new Vector3(0.0f, 9.81f, 0.0f) * Time.deltaTime;

        // check if player has pressed jump key and hasn't aleady jumped
        if (Input.GetKey(KeyCode.Space) &&
            !(transform.position.y >= 0.0f))
        {
            // modify velocity for jump
            velocity += transform.up * Time.deltaTime * JumpHeight;
        }

        // apply velocity
        transform.position += velocity;

        // velocity loses energy over time
        velocity -= transform.up * Time.deltaTime * energyLoss;

        // if player is below the ground
        if (transform.position.y <= 0.0f)
        {
            transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
        }
    }


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