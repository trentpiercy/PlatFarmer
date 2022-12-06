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
            playerHealth.Respawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == enemyLayer)
        {
            Debug.Log("Hit Enemy!");

            // Tell enemy we hit it
            // TODO this is not epic code, always assuming enemy is parent of trigger
            if (other.transform.parent != null && 
                other.transform.parent.TryGetComponent(out Enemy enemy))
            {
                Debug.Log("valid enemy hit");
                enemy.Hit(transform);

                LoseLife();
                StartCoroutine(HitEnemy(other.transform));
            }

            // Restart
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private IEnumerator HitEnemy(Transform enemy)
    {
        // Disable movement temporarily
        GetComponent<PlayerMovement>().enabled = false;

        // Hit color
        farmerSprite.color = newColor;

        // Bounce the player back
        if (enemy.position.x < transform.position.x)
        {
            //rb.AddForce(new Vector2(forceX, forceY));
            rb.velocity = new Vector2(forceX, forceY);
        }
        else
        {
            //rb.AddForce(new Vector2(-forceX, forceY));
            rb.velocity = new Vector2(-forceX, forceY);
        }

        yield return new WaitForSeconds(waitTime);

        // Back to original color
        farmerSprite.color = originalColor;

        // Re-enable movement
        GetComponent<PlayerMovement>().enabled = true;
    }

    private void LoseLife()
    {
        playerHealth.hp -= 1;

        if (playerHealth.hp == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        Collected.SetHeartColor(playerHealth.hp, Color.black);
        deathSound.Play();
    }
}
