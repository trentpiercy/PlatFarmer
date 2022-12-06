using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collected : MonoBehaviour
{
    static PlayerHealth playerHealth;
    public PlayerHealth setPlayerHealth;
    static int numCollected = 0;

    static Image[] gems;
    public Image[] setGems;
    static Image[] hearts;
    public Image[] setHearts;

    public string setWinScene;
    static string winScene;

    private void Start()
    {
        hearts = setHearts;
        gems = setGems;
        playerHealth = setPlayerHealth;
        winScene = setWinScene;
    }

    public static void GemCollected()
    {
        gems[numCollected].color = Color.white;
        numCollected++;

        if (numCollected == gems.Length)
        {
            SceneManager.LoadScene(winScene, LoadSceneMode.Single);
        }
    }

    public static void GainLife(GameObject heartItem)
    {
        if (playerHealth.hp < playerHealth.totalHealth)
        {
            playerHealth.hp += 1;
            SetHeartColor(playerHealth.hp-1, Color.white);
            Destroy(heartItem);
        }

    }

    public static void SetHeartColor(int heart, Color color)
    {
        hearts[heart].color = color;
    }
}
