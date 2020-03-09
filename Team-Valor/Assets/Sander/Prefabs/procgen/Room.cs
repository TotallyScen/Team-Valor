using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private GameObject Manager;
    public List<GameObject> doorWays = new List<GameObject>();
    public GameObject[] doorRoomSpawners;

    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("ScriptManager");
    }

    private void Update()
    {
      
    }

}
