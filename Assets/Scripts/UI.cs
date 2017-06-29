using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text scoreText;
    public GameController controller;

	void Update ()
    {
        scoreText.text = "Enemies Remaining: " + controller.currentTerritory.GetEnemiesRemaining();
	}
}
