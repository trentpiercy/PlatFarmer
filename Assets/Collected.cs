using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Collected : MonoBehaviour
{
    static PlayerHealth playerHealth;
    public PlayerHealth setPlayerHealth;
    static int numCollected = 0;
    static Image[] gems;
    public Image[] setGems;
    static Image[] hearts;
    public Image[] setHearts;
    //static AudioSource collectSound;

    private void Start()
    {
        hearts = setHearts;
        gems = setGems;
        playerHealth = setPlayerHealth;
    }

    public static void gemCollected()
    {
        //collectSound.Play();
        gems[numCollected].color = Color.white;
        numCollected++;
    }
    public static void gainLife(GameObject heartItem)
    {
        if (playerHealth.hp < playerHealth.totalHealth)
        {
            //collectSound.Play();
            playerHealth.hp += 1;
            Collected.setHeartColor(playerHealth.hp-1, Color.white);
            Destroy(heartItem);
        }

    }

    public static void setHeartColor(int heart, Color color)
    {
        hearts[heart].color = color;
    }
}
