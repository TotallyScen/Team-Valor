using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ScriptableObject
{
    public string enemyName;
    public float moveSpeed;
    public float health;
    public float damage;
    public int spawnIndex;
    public GameObject prefab;


    public virtual void Attack()
    {

    }

    public virtual void Move()
    {

    }
}
