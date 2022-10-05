using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopTree : MonoBehaviour
{ 
    public LayerMask trees;
    public Transform chopLocation;
    public float chopRange;

    private Rigidbody2D body;
    private Quaternion target;
 
    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            
            Collider2D[] hitTrees = Physics2D.OverlapCircleAll( chopLocation.position, chopRange, trees );

            for (int i = 0; i < hitTrees.Length; i++)
            {
                hitTrees[i].gameObject.GetComponent<TreeFall>().fallDown();
            }
        }            
    }
}