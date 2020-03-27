using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public Vector3 offset;
    public Transform spawnLoc;
    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerBehaviour>().moveAllow == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(projectile, spawnLoc.position, spawnLoc.rotation);
            }
        }
    }
}
