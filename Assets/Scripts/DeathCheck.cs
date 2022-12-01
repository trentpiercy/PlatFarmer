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
            LoseLife();
        }
    }

    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == enemyLayer)
        {
            // Tell enemy we hit it
            // TODO this is not epic code
            var enemy = other.transform.parent.GetComponent<Enemy>();
            enemy.Hit(transform);

            // Make player lose a life
            LoseLife();

            // Disable movement temporarily
            GetComponent<PlayerMovement>().enabled = false;

            // Play hit sound
            deathSound.Play();

            // Hit color
            farmerSprite.color = newColor;

            // Bounce the player back
            if (other.gameObject.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(forceX, forceY));
                //rb.velocity = new Vector2(forceX, forceY);
            }
            else
            {
                rb.AddForce(new Vector2(-forceX, forceY));
                //rb.velocity = new Vector2(-forceX, forceY);
            }

            yield return new WaitForSeconds(waitTime);

            // Back to original color
            farmerSprite.color = originalColor;

            // Re-enable movement
            GetComponent<PlayerMovement>().enabled = true;
            

            // Restart
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void LoseLife()
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
