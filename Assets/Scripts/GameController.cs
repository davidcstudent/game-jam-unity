﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (currentTerritory.GetEnemiesRemaining() == 0)
        {
            gameOver = true;
        }

        if (gameOver)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Main_Menu");
        }
    }
}
