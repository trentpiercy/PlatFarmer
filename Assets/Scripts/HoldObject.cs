using UnityEngine;
using UnityEngine.Events;

public class HoldObject : MonoBehaviour
{
    // Reference to where you want your object to go
    public GameObject playerHands;
    
    // The gameobject you collided with
    private GameObject collidedWith;

    private bool canpickup = false;
    private bool hasItem = false;
 

    void Update()
    {
        if (canpickup && Input.GetKeyDown(KeyCode.F)) // if you enter the collider of the object
        {
            Debug.Assert(collidedWith != null);

            Debug.Log("Picked up!");
            //collidedWith.GetComponent<Rigidbody2D>().isKinematic = true;
            collidedWith.transform.position = playerHands.transform.position; // sets the position of the object to your hand position
            collidedWith.transform.parent = playerHands.transform; //makes the object become a child of the parent so that it moves with the hands

            hasItem = true;
        } else if (hasItem && Input.GetKeyDown(KeyCode.F)) // drop
        {
            Debug.Assert(collidedWith != null);

            Debug.Log("Put down!");
            //collidedWith.GetComponent<Rigidbody2D>().isKinematic = false;
            collidedWith.transform.parent = null; // make the object no be a child of the hands

            hasItem = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (hasItem) return;
        if (other.gameObject.CompareTag("object"))
        {
            canpickup = true;  
            collidedWith = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canpickup = false; 
    }
}