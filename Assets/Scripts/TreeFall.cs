using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFall : MonoBehaviour
{
    // Transform to move this tree to after being chopped
    public Transform choppedTransform;

    // Has this tree been chopped yet
    private bool chopped = false;

    public void FallDown(){
        if (chopped) return;

        Debug.Assert(choppedTransform != null);

        gameObject.GetComponent<Transform>().position = choppedTransform.position;
        gameObject.GetComponent<Transform>().rotation = choppedTransform.rotation;

        chopped = true;
    }
}
