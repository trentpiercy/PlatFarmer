using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collected.gemCollected();
            Destroy(gameObject);
        }
    }
}
