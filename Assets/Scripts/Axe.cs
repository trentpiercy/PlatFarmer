using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public LayerMask treesLayer;
    public LayerMask enemiesLayer;

    // Point to check chop range from
    public Transform chopLocation;

    // How far can the player reach to chop a tree
    public float chopRange;


    // Angle to rotate axe to when chopping
    private readonly float axeChopDegrees = 60;

    // How long to show axe at axeChopDegrees
    private readonly float animationDelay = 0.2f;

    private bool isChopping = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && !isChopping){

            isChopping = true;
            transform.Rotate(new Vector3(0, 0, -axeChopDegrees));

            // Check for hitting trees
            Collider2D[] hitTrees = Physics2D.OverlapCircleAll(chopLocation.position, chopRange, treesLayer);
            for (int i = 0; i < hitTrees.Length; i++)
            {
                hitTrees[i].gameObject.GetComponent<TreeFall>().FallDown();
            }

            // Check for hitting enemies
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(chopLocation.position, chopRange, enemiesLayer);
            for (int i = 0; i < hitEnemies.Length; i++)
            {
                Debug.Log("Hit enemy!");
                hitEnemies[i].gameObject.GetComponent<Enemy>().callOnAttacked.Invoke();
            }

            StartCoroutine(ChopWait());
        }
    }

    IEnumerator ChopWait()
    {
        yield return new WaitForSeconds(animationDelay);

        transform.Rotate(new Vector3(0, 0, axeChopDegrees));
        isChopping = false;
    }
}