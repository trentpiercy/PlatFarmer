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

    private bool isChopping = false;
    private float chopDegrees = 60;
    private float delay = 0.2f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isChopping){

            isChopping = true;
            transform.Rotate(new Vector3(0, 0, -chopDegrees));

            Collider2D[] hitTrees = Physics2D.OverlapCircleAll(chopLocation.position, chopRange, treesLayer);
            for (int i = 0; i < hitTrees.Length; i++)
            {
                hitTrees[i].gameObject.GetComponent<TreeFall>().FallDown();
            }

            StartCoroutine(ChopWait());
        }
    }

    IEnumerator ChopWait()
    {
        yield return new WaitForSeconds(delay);

        transform.Rotate(new Vector3(0, 0, chopDegrees));
        isChopping = false;
    }
}