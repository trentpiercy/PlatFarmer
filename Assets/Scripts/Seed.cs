using UnityEngine;
using UnityEngine.Events;

public class Seed : MonoBehaviour
{
    // Reference to where you want your object to go
    public GameObject myHands;
    
    // The gameobject onwhich you collided with
    GameObject ObjectIwantToPickUp;
    bool canpickup = false;
    bool hasItem = false;
 

    void Update()
    {
        if (canpickup && Input.GetKeyDown(KeyCode.F)) // if you enter the collider of the object
        {
            Debug.Log("Picked up!");
            //ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = true;  
            ObjectIwantToPickUp.transform.position = myHands.transform.position; // sets the position of the object to your hand position
            ObjectIwantToPickUp.transform.parent = myHands.transform; //makes the object become a child of the parent so that it moves with the hands

            hasItem = true;
        } else if (hasItem && Input.GetKeyDown(KeyCode.F)) //drop
        {
            Debug.Log("Put down!");
            //ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = false; 
            //ObjectIwantToPickUp.transform.position = myHands.transform.position; // sets the position of the object to your hand position
            ObjectIwantToPickUp.transform.parent = null; // make the object no be a child of the hands

            hasItem = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (hasItem) return;

        Debug.Log("Collision");
        if(other.gameObject.tag.Equals("object"))
        {
            canpickup = true;  
            ObjectIwantToPickUp = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canpickup = false; 
    }
}