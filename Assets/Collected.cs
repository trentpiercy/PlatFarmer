using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Collected : MonoBehaviour
{
    static int numCollected = 0;
    static Image[] gems;
    public Image[] setGems;
    static Image[] hearts;
    public Image[] setHearts;

    private void Start()
    {
        hearts = setHearts;
        gems = setGems;
    }

    public static void gemCollected()
    {
        gems[numCollected].color = Color.white;
        numCollected++;
    }
    //public static void gainLife()
    //{
    //    playerHealth.hp += 1;
    //    Collected.setHeartColor(playerHealth.hp, Color.white);
    //}

    public static void setHeartColor(int heart, Color color)
    {
        hearts[heart].color = color;
    }



    //// Update is called once per frame
    //void Update()
    //{
    //    GetComponentInChildren<TextMeshProUGUI>().SetText("Collected {0} of {1}", numCollected, totalAvailable);
    //}
}
