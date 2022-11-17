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
    private Color originalColor;
    public SpriteRenderer farmerSprite;
    public float newGravity = 2f;
    public float newDrag = 2f;
    private float waitTime = .3f;
    private float originalGravity;
    public int enemyLayer;
    public AudioSource deathSound;

    private void Start()
    {
        originalColor = farmerSprite.color;
        originalGravity = GetComponent<Rigidbody2D>().gravityScale;

    }
    private IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == enemyLayer)
        {
            if (other.gameObject.transform.position.x < transform.position.x)
            {
                GetComponent<Rigidbody2D>().gravityScale = newGravity;
                GetComponent<Rigidbody2D>().drag = newDrag;
                GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(forceX, forceY), transform.position);
                farmerSprite.color = newColor;
                deathSound.Play();
                yield return new WaitForSeconds(waitTime);
                farmerSprite.color = originalColor;
                GetComponent<Rigidbody2D>().drag = 0;
                GetComponent<Rigidbody2D>().gravityScale = originalGravity;


            }
            else
            {
                GetComponent<Rigidbody2D>().gravityScale = newGravity;
                GetComponent<Rigidbody2D>().drag = newDrag;
                GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(-forceX, forceY), transform.position);
                farmerSprite.color = newColor;
                yield return new WaitForSeconds(waitTime);
                farmerSprite.color = originalColor;
                GetComponent<Rigidbody2D>().drag = 0;
                GetComponent<Rigidbody2D>().gravityScale = originalGravity;
            }


            //// Restart
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
