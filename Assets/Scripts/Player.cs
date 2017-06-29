using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float movementDistance;
    public float cameraSpeedHorizontal = 2.0f;
    public float cameraSpeedVertical = 2.0f;

    public GameObject cameraRotator;

    private float yaw = 0;
    private float pitch = 0;
    private Weapon currentWeapon;

	// Use this for initialization
	void Start ()
    {
        currentWeapon = GetComponent<Weapon>();
	}
	
	// Update is called once per frame
	void Update () {

        // WASD input
        // ---------------------------------------------------
        // Forward
        if (Input.GetKey(KeyCode.W))
        {
            //// get new player position
            //Vector3 playerPosition;
            //playerPosition.x = this.transform.position.x;
            //playerPosition.y = this.transform.position.y;
            //playerPosition.z = this.transform.position.z + movementDistance * Time.deltaTime;
            //// set players postion
            // this.transform.position = playerPosition;
            transform.position += transform.forward * Time.deltaTime * movementDistance;

        }
        // Left
        if (Input.GetKey(KeyCode.A))
        {
            //// get new player position
            //Vector3 playerPosition;
            //playerPosition.x = this.transform.position.x - movementDistance * Time.deltaTime;
            //playerPosition.y = this.transform.position.y;
            //playerPosition.z = this.transform.position.z;
            //// set players postion
            //this.transform.position = playerPosition;
            transform.position -= transform.right * Time.deltaTime * movementDistance;
        }
        // Down
        if (Input.GetKey(KeyCode.S))
        {
            //// get new player position
            //Vector3 playerPosition;
            //playerPosition.x = this.transform.position.x;
            //playerPosition.y = this.transform.position.y;
            //playerPosition.z = this.transform.position.z - movementDistance * Time.deltaTime;
            //// set players postion
            //this.transform.position = playerPosition;
            transform.position -= transform.forward * Time.deltaTime * movementDistance;
        }
        // Right
        if (Input.GetKey(KeyCode.D))
        {
            //// get new player position
            //Vector3 playerPosition;
            //playerPosition.x = this.transform.position.x + movementDistance * Time.deltaTime;
            //playerPosition.y = this.transform.position.y;
            //playerPosition.z = this.transform.position.z;
            //// set players postion
            //this.transform.position = playerPosition;
            transform.position += transform.right * Time.deltaTime * movementDistance;
        }
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
}
