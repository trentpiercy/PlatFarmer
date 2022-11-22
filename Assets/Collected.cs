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

    public static void gemCollected()
    {
        gems[numCollected].color = Color.white;
        numCollected++;
    }

    private void Start()
    {
        gems = setGems;
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    GetComponentInChildren<TextMeshProUGUI>().SetText("Collected {0} of {1}", numCollected, totalAvailable);
    //}
}
