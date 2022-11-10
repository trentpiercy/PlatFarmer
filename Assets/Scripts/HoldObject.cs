using UnityEngine;
using UnityEngine.Events;

public class HoldObject : MonoBehaviour
{
    // Reference to where you want your object to go
    public GameObject playerHands;

    private GameObject heldItem;
    public LayerMask itemLayerMask;


    void Update()
    {
        if (heldItem == null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (GetComponent<Collider2D>().IsTouchingLayers(itemLayerMask))
                {
                    Debug.Log("Touching item");
                    Collider2D[] items = Physics2D.OverlapCircleAll(transform.position, 0.5f, itemLayerMask);

                    if (items.Length == 0) return;

                    // Pickup the first item
                    heldItem = items[0].gameObject;
                    heldItem = heldItem.transform.parent.gameObject;
                    heldItem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                    if (heldItem.CompareTag("Axe"))
                    {
                        heldItem.GetComponent<Axe>().enabled = true;
                        heldItem.transform.position = playerHands.transform.position;
                    }
                    else if (heldItem.CompareTag("Log"))
                    {
                        heldItem.layer = LayerMask.NameToLayer("IgnorePlayer");
                        if (heldItem.transform.position.x > playerHands.transform.position.x - .2f)
                        {
                            Debug.Log("item is ahead");
                            heldItem.transform.position = playerHands.transform.position + new Vector3(.5f, 0, 0);
                        }
                        else
                        {
                            Debug.Log("you are ahead");
                            heldItem.transform.position = playerHands.transform.position + new Vector3(-.5f, 0, 0);
                        }
                    }
                    else
                    {
                        heldItem.transform.position = playerHands.transform.position; // sets the position of the object to your hand position
                    }
                    heldItem.transform.parent = playerHands.transform;// makes the object become a child of the parent so that it moves with the hands
                }
            }
        }
        else // Item held
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                DropItem();
            }
            else if (Input.GetKeyDown(KeyCode.G))
            {
                if (heldItem.CompareTag("Seed"))
                {
                    heldItem.GetComponent<Seed>().Drop();
                    DropItem();
                } else if (heldItem.CompareTag("Water"))
                {
                    heldItem.GetComponent<WaterDroplet>().Drop();
                    DropItem();
                }
            }
        }
    }

    private void DropItem()
    {
        Debug.Assert(heldItem != null);
        Debug.Log("Put down!");

        heldItem.transform.parent = null; // make the object not be a child of the hands

        heldItem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        if (heldItem.CompareTag("Axe"))
        {
            heldItem.GetComponent<Axe>().enabled = false;
        }
        else if (heldItem.CompareTag("Log"))
        {
            heldItem.layer = LayerMask.NameToLayer("Default");
        }

        heldItem = null;
    }
}