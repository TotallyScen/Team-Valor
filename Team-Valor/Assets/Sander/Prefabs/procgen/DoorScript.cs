using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject Manager;
    public bool hasSpace;
    public float rayLenght;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("ScriptManager");


        if (!Physics.Raycast(transform.position, transform.forward, rayLenght))
        {

            Manager.GetComponent<RoomManager>().StartCoroutine(Manager.GetComponent<RoomManager>().InstRoom(transform));

        }

        else
        {
            print("yeet");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
