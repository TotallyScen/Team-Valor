using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 dir;
    public float speed;
    public float damage;
    public float aliveTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);

        aliveTime -= Time.deltaTime;

        if(aliveTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Health>().health -= damage;
            Destroy(gameObject);
        }
        else if (other.tag == "Enviroment")
        {
            Destroy(gameObject);
        }
    }
}
