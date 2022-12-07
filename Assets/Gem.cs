using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gem : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collected gem");
            Collected.GemCollected();
            Destroy(gameObject);
        }
    }
}
