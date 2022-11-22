using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{     
    public string nextLevel;
    public AudioSource success;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            success.Play();
            Debug.Log("At barn!");
            StartCoroutine(loadCoroutine());
        }
    }

    IEnumerator loadCoroutine()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);

    }
}
