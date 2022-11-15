using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCheck : MonoBehaviour
{
    public float deathY = -20;

    public int enemyLayer;
    public AudioSource deathYell;
    private void FixedUpdate()
    {
        if (transform.position.y < deathY)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //RespawnAfterFall.hasFallen = true;
            deathYell.Play();
            GetComponent<RespawnAfterFall>().Respawn();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == enemyLayer)
        {
            // Restart
            deathYell.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
