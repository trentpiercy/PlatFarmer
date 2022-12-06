using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopBean : MonoBehaviour
{
    public GameObject seed;
    // Start is called before the first frame update
    public void Fall()
    {
        Debug.Log("Bean fall");
        Instantiate(seed, transform.position, new Quaternion());
        Destroy(gameObject);
    }
}
