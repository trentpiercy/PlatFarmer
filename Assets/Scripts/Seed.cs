using UnityEngine;
using UnityEngine.Events;

public class Seed : MonoBehaviour
{
    public GameObject myHands; //reference to where you want your object to go
    bool canpickup; 
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    bool hasItem; 

    // Start is called before the first frame update
    void Start()
    {
        canpickup = false;    
        hasItem = false;
    }
 
    // Update is called once per frame
    void Update()
    {
        Debug.Log(canpickup);
        if(canpickup == true && Input.GetKeyDown("e")) // if you enter the collider of the object
        {
            Debug.Log("Picked up!");
            ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = true;  
            ObjectIwantToPickUp.transform.position = myHands.transform.position; // sets the position of the object to your hand position
            ObjectIwantToPickUp.transform.parent = myHands.transform; //makes the object become a child of the parent so that it moves with the hands
        }
        if (Input.GetKeyDown("q") && hasItem == true) //drop
        {
            Debug.Log("Put down!");
            ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = false; 
            ObjectIwantToPickUp.transform.position = myHands.transform.position; // sets the position of the object to your hand position
            ObjectIwantToPickUp.transform.parent = null; // make the object no be a child of the hands
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Collision"); //This isn't working
        if(other.gameObject.tag == "object") 
        {
            canpickup = true;  
            ObjectIwantToPickUp = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canpickup = false; 
     
    }
}