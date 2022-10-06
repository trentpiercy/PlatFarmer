using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopTree : MonoBehaviour
{
    public LayerMask treesLayer;

    // Point to check chop range from
    public Transform chopLocation;

    // How far can the player reach to chop a tree
    public float chopRange;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){

            Collider2D[] hitTrees = Physics2D.OverlapCircleAll(chopLocation.position, chopRange, treesLayer);
            for (int i = 0; i < hitTrees.Length; i++)
            {
                hitTrees[i].gameObject.GetComponent<TreeFall>().FallDown();
            }
        }
    }
}