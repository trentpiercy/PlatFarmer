using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public LayerMask treesLayer;
    public LayerMask enemiesLayer;

    // Point to check chop range from
    public Transform swingLocation;

    // How far can the player reach to chop a tree
    public float swingRange = 1f;

    // How long to chop for and show animation
    public float chopTime = 0.2f;

    // Angle to rotate axe to when chopping
    private readonly float torchSwingDegrees = 60;

    private bool isUsing = false;
    public AudioSource useTorch;

    private void Start()
    {
        enabled = false;
        swingLocation = transform;
    }

    private void HitCheck()
    {
        // Check for hitting trees
        Collider2D[] hitTrees = Physics2D.OverlapCircleAll(swingLocation.position, swingRange, treesLayer);
        for (int i = 0; i < hitTrees.Length; i++)
        {
            useTorch.Play();
            Debug.Log("burn tree");
            StartCoroutine(hitTrees[i].gameObject.GetComponent<Tree>().Burn());
            isUsing = false;
        }

        // Check for hitting enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(swingLocation.position, swingRange, enemiesLayer);
        for (int i = 0; i < hitEnemies.Length; i++)
        {
            useTorch.Play();
            Debug.Log("Hit enemy!");
            StartCoroutine(hitEnemies[i].gameObject.GetComponent<Enemy>().Burn());

        }
    }

    private void Update()
    {
        // If not chopping and trying to, start chopping
        if ((Input.GetKeyDown(KeyCode.G) || Input.GetMouseButtonDown(0)) && !isUsing)
        {

            isUsing = true;
            transform.Rotate(new Vector3(0, 0, -torchSwingDegrees));

            StartCoroutine(ChopWait());
        }

        // If currently chopping, check for hitsf
        if (isUsing)
        {
            HitCheck();
        }
    }

    IEnumerator ChopWait()
    {
        yield return new WaitForSeconds(chopTime);

        transform.Rotate(new Vector3(0, 0, torchSwingDegrees));
        isUsing = false;
    }
}