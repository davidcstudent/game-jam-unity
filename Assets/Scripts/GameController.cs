﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool gameOver = false;
    public Territory currentTerritory;

	void Start ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameOver = true;
        }

        if (gameOver)
        {
            Application.Quit();
        }
    }
}
