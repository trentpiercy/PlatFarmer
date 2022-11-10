using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.name == "Player")
        {
            collision2D.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.name == "Player")
        {
            collision2D.gameObject.transform.SetParent(null);
        }
    }
    
}
