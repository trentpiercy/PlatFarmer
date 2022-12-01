using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class HoldObject : MonoBehaviour
{
    // Reference to where you want your object to go
    public GameObject playerHands;
    public GameObject waterDrop;
    public BoxCollider2D waterCheck;
    private GameObject heldItem;
    public LayerMask itemLayerMask;
    public LayerMask waterLayerMask;
    public AudioSource collectSound;
    public SpriteRenderer waterCan;

    void Update()
    {
        if (heldItem == null)
        {
            // No held item
            if (Binds.pickupDrop()
                && GetComponent<Collider2D>().IsTouchingLayers(itemLayerMask))
            {
                Debug.Log("Touching item");
                Collider2D[] items = Physics2D.OverlapCircleAll(transform.position, 0.5f, itemLayerMask);
                if (items.Length == 0) return;

                // Pickup the first item
                heldItem = items[0].gameObject;
                heldItem = heldItem.transform.parent.gameObject;
                heldItem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                collectSound.Play();

                if (heldItem.CompareTag("Axe") || heldItem.CompareTag("Torch"))
                {
                    if (heldItem.CompareTag("Axe"))
                    {
                        heldItem.GetComponent<Axe>().enabled = true;
                    }
                    else
                    {
                        heldItem.GetComponent<Torch>().enabled = true;
                    }

                    bool playerFaceForward = playerHands.transform.position.x > playerHands.transform.parent.position.x;
                    bool axAheadPlayer = heldItem.transform.position.x > playerHands.transform.parent.position.x;
                    if (playerFaceForward)
                    {
                        heldItem.transform.position = playerHands.transform.position;
                        //heldItem.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                        Debug.Log(heldItem.transform.localScale);
                    }
                    else
                    {
                        heldItem.transform.position = playerHands.transform.position;
                        //heldItem.transform.localScale = new Vector3(0.5f, -0.5f, 0.5f);
                        Debug.Log(heldItem.transform.localScale);
                    }
                }
                else if (heldItem.CompareTag("Log"))
                {
                    heldItem.layer = LayerMask.NameToLayer("IgnorePlayer");
                    if (heldItem.transform.position.x > playerHands.transform.position.x - .2f)
                    {
                        heldItem.transform.position = playerHands.transform.position + new Vector3(.5f, 0, 0);
                    }
                    else
                    {
                        heldItem.transform.position = playerHands.transform.position + new Vector3(-.5f, 0, 0);
                    }
                }
                else
                {
                    heldItem.transform.position = playerHands.transform.position;
                    //heldItem.transform.localScale = new Vector3(0.5f, -0.5f, 0.5f);
                    Debug.Log(heldItem.transform.localScale);
                }
                heldItem.transform.parent = playerHands.transform;// makes the object become a child of the parent so that it moves with the hands
            }

            else if (Binds.pickupDrop() && waterCheck.IsTouchingLayers(waterLayerMask))
            {
                Debug.Log("trying to pick up water");
                heldItem = Instantiate(waterDrop);
                heldItem.transform.position = playerHands.transform.position;
                heldItem.transform.parent = playerHands.transform;
                heldItem.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
        }

        else // Item already held
        {
            if (Binds.pickupDrop())
            {
                DropItem();
            }
            else if (Binds.use())
            {
                // Use item, drop if seed or water
                if (heldItem.CompareTag("Seed"))
                {
                    heldItem.GetComponent<Seed>().DropToPlant();
                    DropItem();
                }
                else if (heldItem.CompareTag("Water"))
                {
                    StartCoroutine(ShowWaterCan());
                    heldItem.GetComponent<WaterDroplet>().DropToPlant();
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
        else if (heldItem.CompareTag("Torch"))
        {
            heldItem.GetComponent<Torch>().enabled = false;
        }
        else if (heldItem.CompareTag("Log"))
        {
            heldItem.layer = LayerMask.NameToLayer("IgnoreIgnorePlayer");
        }

        heldItem = null;
    }

    private IEnumerator ShowWaterCan()
    {
        waterCan.enabled = true;
        yield return new WaitForSeconds(0.5f);
        waterCan.enabled = false;
    }
}