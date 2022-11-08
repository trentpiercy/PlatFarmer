using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public LayerMask treesLayer;
    public LayerMask enemiesLayer;

    // Point to check chop range from
    public Transform chopLocation;

    // How far can the player reach to chop a tree
    public float chopRange;

    // How long to chop for and show animation
    public float chopTime = 0.2f;

    // Angle to rotate axe to when chopping
    private readonly float axeChopDegrees = 60;

    private bool isChopping = false;

    private void HitCheck()
    {
        // Check for hitting trees
        Collider2D[] hitTrees = Physics2D.OverlapCircleAll(chopLocation.position, chopRange, treesLayer);
        for (int i = 0; i < hitTrees.Length; i++)
        {
            StartCoroutine(hitTrees[i].gameObject.GetComponent<Tree>().Burn());
            isChopping = false;
        }

        // Check for hitting enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(chopLocation.position, chopRange, enemiesLayer);
        for (int i = 0; i < hitEnemies.Length; i++)
        {
            Debug.Log("Hit enemy!");
            hitEnemies[i].gameObject.GetComponent<Enemy>().Burn();
        }
    }

    private void Update()
    {
        // If not chopping and trying to, start chopping
        if ((Input.GetKeyDown(KeyCode.G) || Input.GetMouseButtonDown(0)) && !isChopping)
        {

            isChopping = true;
            transform.Rotate(new Vector3(0, 0, -axeChopDegrees));

            StartCoroutine(ChopWait());
        }

        // If currently chopping, check for hits
        if (isChopping)
        {
            HitCheck();
        }
    }

    IEnumerator ChopWait()
    {
        yield return new WaitForSeconds(chopTime);

        transform.Rotate(new Vector3(0, 0, axeChopDegrees));
        isChopping = false;
    }
}