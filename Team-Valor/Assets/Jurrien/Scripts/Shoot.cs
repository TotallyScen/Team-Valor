using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public Vector3 offset;
    public Transform spawnLoc;
    public float attackDelay;
    public bool isAttacking;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerBehaviour>().moveAllow == true && !isAttacking)
        {
            if (Input.GetButton("Fire1"))
            {
                isAttacking = true;
                StartCoroutine(Attack());
            }
        }
    }

    public IEnumerator Attack()
    {
        Instantiate(projectile, spawnLoc.position, spawnLoc.rotation);
        yield return new WaitForSeconds(attackDelay);
        isAttacking = false;
    }
}


