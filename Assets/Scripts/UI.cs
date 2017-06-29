﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text scoreText;
    public GameController controller;
    public Image healthImage;
    public Sprite[] sprites = new Sprite[5];

    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update ()
    {
        scoreText.text = "Enemies Remaining: " + controller.currentTerritory.GetEnemiesRemaining();

        float playerHealthPercent = player.getHealthPercent();
        
        if (playerHealthPercent > 0.75f)
        {
            healthImage.sprite = sprites[0];
        }
        else if (playerHealthPercent > 0.5f)
        {
            healthImage.sprite = sprites[1];
        }
        else if (playerHealthPercent > 0.25f)
        {
            healthImage.sprite = sprites[2];
        }
        else if (playerHealthPercent > 0f)
        {
            healthImage.sprite = sprites[3];
        }
        else
        {
            healthImage.sprite = sprites[4];
        }
    }
}
