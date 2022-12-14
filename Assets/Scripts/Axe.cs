using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public LayerMask treesLayer;
    public LayerMask beanLayer;
    public LayerMask enemiesLayer;
    public LayerMask saplingLayer;

    // Point to check chop range from
    public Transform chopLocation;

    // How far can the player reach to chop a tree
    public float chopRange;

    // How long to chop for and show animation
    public float chopTime = 0.2f;
    public float chopCooldown = 2;

    // Angle to rotate axe to when chopping
    private readonly float axeChopDegrees = 60;
    private float axeCurrentAngle = 0;

    private bool isChopping = false;
    private bool isCoolingdown = false;
    public AudioSource chopSound;

    public Vector3 initialScale;
    public Quaternion initialRotation;

    private void Awake()
    {
        initialRotation = transform.rotation;
        initialScale = transform.localScale;
        enabled = false;
    }

    private void HitCheck()
    {
        //Debug.Log("in hitcheck");
        // Check for hitting trees
        Collider2D[] hitTrees = Physics2D.OverlapCircleAll(chopLocation.position, chopRange, treesLayer);
        Collider2D[] hitBeans = Physics2D.OverlapCircleAll(chopLocation.position, chopRange, beanLayer);
        Debug.Log("in hitcheck " + hitTrees);

        for (int i = 0; i < hitTrees.Length; i++)
        {
            //hitTrees[i].gameObject.GetComponent<TreeFall>().FallDown();
            hitTrees[i].gameObject.GetComponent<Tree>().ChopTree();
            isChopping = false;
        }
        for (int i = 0; i < hitBeans.Length; i++)
        {
            hitBeans[i].gameObject.GetComponent<ChopBean>().Fall();
            isChopping = false;
        }
        
        // Check for hitting enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(chopLocation.position, chopRange, enemiesLayer);
        for (int i = 0; i < hitEnemies.Length; i++)
        {
            Debug.Log("Hit enemy!");
            if (hitEnemies[i].gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.Attacked();
            }
        }

        // Check for hitting saplings
        Collider2D[] hitSaplings = Physics2D.OverlapCircleAll(chopLocation.position, chopRange, saplingLayer);
        for (int i = 0; i < hitSaplings.Length; i++)
        {
            Debug.Log("Hit sapling!");
            hitSaplings[i].GetComponent<Sapling>().Chop();
        }
    }

    public void Update()
    {
        // If not chopping and trying to, start chopping
        if (Binds.use() && !isChopping && !isCoolingdown)
        {
            Debug.Log("in update");
            isChopping = true;
            // transform.Rotate(new Vector3(0, 0, -axeChopDegrees));
            chopSound.Play();
            isCoolingdown = true;
            StartCoroutine(ChopWait());
        }

        // If currently chopping, check for hits
        if (isChopping)
        {
            Debug.Log(axeCurrentAngle > -axeChopDegrees);
            if (axeCurrentAngle > -axeChopDegrees)
            {
                Debug.Log("Chopping");
                float choppingAngleDelta = -Mathf.Min(axeChopDegrees / chopTime, Mathf.Abs(axeChopDegrees - axeCurrentAngle));
                axeCurrentAngle += choppingAngleDelta;
                transform.Rotate(new Vector3(0, 0, choppingAngleDelta));
            }
            HitCheck();
        }
        else if (axeCurrentAngle < 0)
        {
            Debug.Log("Coolingdown");
            float relaxingAngleDelta = Mathf.Min(axeChopDegrees / chopCooldown, -axeCurrentAngle);
            axeCurrentAngle += relaxingAngleDelta;
            transform.Rotate(new Vector3(0, 0, relaxingAngleDelta));
        }
    }

    IEnumerator ChopWait()
    {
        yield return new WaitForSeconds(chopTime);

        isChopping = false;
        yield return new WaitForSeconds(chopCooldown);
        // transform.Rotate(new Vector3(0, 0, axeChopDegrees));
        isCoolingdown = false;
    }


}