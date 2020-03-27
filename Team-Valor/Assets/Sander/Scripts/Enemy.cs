using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;

    public Health hpScript;
    public AudioSource hitSound;

    public float damage;
    public float attackDelay;
    public GameObject attackFX;

    public GameObject player;
    public GameObject Manager;

    public virtual void Attack()
    {
       
    }

}
