using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Instructions : MonoBehaviour
{
    //public Text text;  //Add reference to UI Text here via the inspector [unable to get this working]
    public Image background;
    //private float timeToAppear = 2f;
    //private float timeWhenDisappear;

    //Call to enable the text, which also sets the timer
    public void EnableText()
    {
        Debug.Log("here");
        background.enabled = true;
        //text.enabled = true;
    }

    //We check every frame if the timer has expired and the text should disappear
    void Update()
    {
        if (background.enabled && (Input.GetKeyDown("space")))
        {
            Debug.Log("STARTING GAME");
            //text.enabled = false;
            background.enabled = false;
        }
    }
}
