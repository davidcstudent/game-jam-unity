using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float movementDistance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // WASD input
        // ---------------------------------------------------
        // Forward
        if (Input.GetKey(KeyCode.W))
        {
            // get new player position
            Vector3 playerPosition;
            playerPosition.x = this.transform.position.x;
            playerPosition.y = this.transform.position.y;
            playerPosition.z = this.transform.position.z + movementDistance * Time.deltaTime;
            // set players postion
            this.transform.position = playerPosition;
        }
        // Left
        if (Input.GetKey(KeyCode.A))
        {
            // get new player position
            Vector3 playerPosition;
            playerPosition.x = this.transform.position.x - movementDistance * Time.deltaTime;
            playerPosition.y = this.transform.position.y;
            playerPosition.z = this.transform.position.z;
            // set players postion
            this.transform.position = playerPosition;
        }
        // Down
        if (Input.GetKey(KeyCode.S))
        {
            // get new player position
            Vector3 playerPosition;
            playerPosition.x = this.transform.position.x;
            playerPosition.y = this.transform.position.y;
            playerPosition.z = this.transform.position.z - movementDistance * Time.deltaTime;
            // set players postion
            this.transform.position = playerPosition;
        }
        // Right
        if (Input.GetKey(KeyCode.D))
        {
            // get new player position
            Vector3 playerPosition;
            playerPosition.x = this.transform.position.x + movementDistance * Time.deltaTime;
            playerPosition.y = this.transform.position.y;
            playerPosition.z = this.transform.position.z;
            // set players postion
            this.transform.position = playerPosition;
        }
        // ---------------------------------------------------
    }
}
