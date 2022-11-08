using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public virtual void Attacked() {}
    public virtual IEnumerator Burn()
    {
        Debug.Log("null return");
        yield return null;
    }
}
