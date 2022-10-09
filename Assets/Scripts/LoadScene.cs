using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    //private bool atbarn = false;
      
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "barn")
        {
            Debug.Log("At barn!");
            //atbarn = true;
            Debug.Log("Loading new scene...");
            SceneManager.LoadScene("Testing Level 2",LoadSceneMode.Single); //change to generalize
        }
    }
}
