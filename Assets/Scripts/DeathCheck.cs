using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCheck : MonoBehaviour
{
    public float deathY = -20;
    public float forceX;
    public float forceY;
    public Color newColor;
    public float waitTime = 0.3f;
    public SpriteRenderer farmerSprite;
    public int enemyLayer;
    public int waterLayer;
    public AudioSource deathSound;

    Color originalColor;
    Rigidbody2D rb;

    PlayerHealth playerHealth;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalColor = farmerSprite.color;
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (transform.position.y < deathY)
        {
            loseLife();
        }
    }

    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == enemyLayer)
        {
            Debug.Log("On Water");
            // TODO this is not epic code
            other.transform.parent.GetComponent<Enemy>().Hit(transform);
            loseLife();
            GetComponent<PlayerMovement>().enabled = false;
            deathSound.Play();
            farmerSprite.color = newColor;

            if (other.gameObject.transform.position.x < transform.position.x)
            {
                rb.velocity = new Vector2(forceX, forceY);
            }
            else
            {
                rb.velocity = new Vector2(-forceX, forceY);
            }

            yield return new WaitForSeconds(waitTime);

            farmerSprite.color = originalColor;
            GetComponent<PlayerMovement>().enabled = true;
            

            //// Restart
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void loseLife()
    {
        playerHealth.Respawn();
        playerHealth.hp -= 1;

        if (playerHealth.hp == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        Collected.setHeartColor(playerHealth.hp, Color.black);
        deathSound.Play();
    }
}
