using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Heart : MonoBehaviour
{
    public AudioSource collectSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collected heart");

            Collected.gainLife(gameObject);
            collectSound.Play();
        }
    }
}
