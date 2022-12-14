using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    public abstract void Attacked();
    public abstract void Burn();
    public abstract void Hit(Transform player);
}
