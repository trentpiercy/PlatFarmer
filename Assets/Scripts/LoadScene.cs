using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{     
    public string nextLevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("At barn!");

            SceneManager.LoadScene(nextLevel,LoadSceneMode.Single);
        }
    }
}
