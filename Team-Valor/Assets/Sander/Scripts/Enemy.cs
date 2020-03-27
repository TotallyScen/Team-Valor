using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;

    public Component hpScript;
    public AudioSource hitSound;

    public float damage;
    public float attackDelay;
    public GameObject attackFX;

    public GameObject player;

    public virtual void Attack()
    {
       
    }

}
