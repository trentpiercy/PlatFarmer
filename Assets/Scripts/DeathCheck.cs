using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCheck : MonoBehaviour
{
    public float deathY = -20;

    public int enemyLayer;

    private void FixedUpdate()
    {
        if (transform.position.y < deathY)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            RespawnAfterFall.hasFallen = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == enemyLayer)
        {
            // Restart
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
