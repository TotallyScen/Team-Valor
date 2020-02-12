using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : Enemy
{
    public bool isAttacking;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking == false)
        {
            RotateToPlayer(gameObject, player.transform.position);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
    }

    private void OnTriggerEnter()
    {
        
    }

    public void RotateToPlayer(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        direction.y = 0;
        obj.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    public override void Attack()
    {
        base.Attack();
    }
}
