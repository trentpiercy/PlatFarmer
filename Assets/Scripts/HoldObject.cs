using UnityEngine;
using UnityEngine.Events;

public class HoldObject : MonoBehaviour
{
    // Reference to where you want your object to go
    public GameObject playerHands;

    public int itemLayer = 10;

    // The gameobject you collided with
    private GameObject collidedWith;
    private bool canpickup = false;
    private bool hasItem = false;


    void Update()
    {
        if (canpickup && !hasItem && Input.GetKeyDown(KeyCode.F)) // if you enter the collider of the object
        {
            Debug.Assert(collidedWith != null);

            Debug.Log("Picked up!");
            
            if (collidedWith.CompareTag("Water"))
            {
                Debug.Log("Picking up water");
                // If collided with water, hold the parent object
                collidedWith = collidedWith.transform.parent.gameObject;
                collidedWith.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
            else if (collidedWith.CompareTag("Seed"))
            {
                Debug.Log("Picking up seed");
                // If collided with seed, hold the parent object
                collidedWith = collidedWith.transform.parent.gameObject;
                collidedWith.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            } else if (collidedWith.CompareTag("Axe"))
            {
                Debug.Log("Picking up axe");
                collidedWith = collidedWith.transform.parent.gameObject;

                collidedWith.GetComponent<ChopTree>().enabled = true;
                collidedWith.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }

            collidedWith.transform.position = playerHands.transform.position; // sets the position of the object to your hand position
            collidedWith.transform.parent = playerHands.transform; // makes the object become a child of the parent so that it moves with the hands

            hasItem = true;
        }
        else if (hasItem && Input.GetKeyDown(KeyCode.F)) // drop
        {
            Debug.Assert(collidedWith != null);

            Debug.Log("Put down!");

            collidedWith.transform.parent = null; // make the object not be a child of the hands
            
            if (collidedWith.CompareTag("Axe")){
                collidedWith.GetComponent<ChopTree>().enabled = false;
                collidedWith.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            } else if (collidedWith.CompareTag("Seed"))
            {
                collidedWith.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            else if (collidedWith.CompareTag("Water"))
            {
                collidedWith.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }

            hasItem = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered trigger, layer: " + other.gameObject.layer);
        if (hasItem) return;
        if (other.gameObject.layer == itemLayer) // Item layer
        {
            Debug.Log("Trigger is item layer");
            canpickup = true;
            collidedWith = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Exit trigger");
        canpickup = false;
    }
}