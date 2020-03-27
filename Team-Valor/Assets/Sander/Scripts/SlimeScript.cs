using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : Enemy //was eerst het idee dat 
{
    private Vector3 direction;
    private GameObject fxClone;
    public float fxDestroyDelay;
    public bool isAttacking;
    public float explotionRadius;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("ScriptManager");
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hpScript.health <= 0)
        {
            hitSound.Play();
            Manager.GetComponent<RoomManager>().monsterCount--;
            Destroy(gameObject);
        }

        if (!isAttacking)
        {
            RotateToPlayer(gameObject, player.transform.position);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }

    }

    void OnTriggerStay(Collider target)
    {
        if(target.tag == "Player")
        {
            Attack();
        }
    }


    public void RotateToPlayer(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        direction.y = 0;
        obj.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    public override void Attack()
    {
        if (!isAttacking)
        {
            hitSound.Play();
            isAttacking = true;
            fxClone = Instantiate(attackFX, transform.position, transform.rotation);
            Destroy(fxClone, fxDestroyDelay);

            Collider[] colliders = Physics.OverlapSphere(transform.position, explotionRadius);
            foreach (Collider hit in colliders)
            {
                if (hit.tag == "Player")
                {
                    hit.GetComponent<Health>().health -= damage;
                }
               
            }

            StartCoroutine(WaitAfterAttack());
        }
       
    }

    public IEnumerator WaitAfterAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        isAttacking = false;
    }
}
