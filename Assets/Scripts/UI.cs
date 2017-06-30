using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text scoreText;
    public Text gameOverText;
    public Text reminderText;
    public GameController controller;
    public Image healthImage;
    public Image Indicator;
    public Image hitMarker;
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

        if (hitMarker.color.a > 0)
        {
            hitMarker.color += new Color(0, 0, 0, -0.02f);
        }

        if (controller.gameOver)
        {
            reminderText.color = Color.white;
            gameOverText.color = Color.white;
            gameOverText.text = "Wasted!";
        }

        if (controller.gameWon)
        {
            reminderText.color = Color.white;
            gameOverText.color = Color.white;
            gameOverText.text = "You took back your turf!";
        }
    }


     public void DamageIndicator(Projectile projectile, GameObject player)
    {
        Quaternion rotation = Quaternion.LookRotation
            (projectile.transform.position - player.transform.position);

        Indicator.rectTransform.localRotation = Quaternion.Euler(0, 0, -rotation.eulerAngles.y);
    }

}
