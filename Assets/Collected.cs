using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Collected : MonoBehaviour
{
    public GameObject player;
    static int numCollected = 0;
    static int damageTaken = 0;
    static Image[] gems;
    public Image[] setGems;
    static Image[] hearts;
    public Image[] setHearts;

    public static void gemCollected()
    {
        gems[numCollected].color = Color.white;
        numCollected++;
    }

    public static void setHeartColor(int heart, Color color)
    {
        hearts[heart].color = color;
    }

    private void Start()
    {
        hearts = setHearts;
        gems = setGems;
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    GetComponentInChildren<TextMeshProUGUI>().SetText("Collected {0} of {1}", numCollected, totalAvailable);
    //}
}
