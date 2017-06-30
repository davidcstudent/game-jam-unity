using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool gameOver = false;
    public bool gameWon = false;
    public Territory currentTerritory;

	void Start ()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameOver && !gameWon)
            {
                gameOver = true;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("Main_Menu");
            }
        }

        if (currentTerritory.GetEnemiesRemaining() == 0)
        {
            gameWon = true;
        }

        if (gameOver || gameWon)
        {
            Time.timeScale = 0;
        }
    }
}
