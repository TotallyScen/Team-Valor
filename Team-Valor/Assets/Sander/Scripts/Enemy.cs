using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public float health;
    public float damage;
    public GameObject attackFX;
    public GameObject player;

    public virtual void Attack()
    {

    }

    public virtual void Move()
    {

    }
}
