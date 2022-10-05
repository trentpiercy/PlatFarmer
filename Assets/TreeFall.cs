using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFall : MonoBehaviour
{
    private Transform t;

    public void fallDown(){
        
        t = gameObject.GetComponent<Transform>();
        t.rotation = Quaternion.Euler(t.rotation.x, t.rotation.y, -44);
        t.position = new Vector3(4.5f, -0.9f, t.position.z);
    }
}
