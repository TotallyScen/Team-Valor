using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private RoomManager rM;
    private GameObject manager;
    public List<GameObject> doorWays = new List<GameObject>();
    public GameObject[] doorRoomSpawners;
    public bool spawnDone;
    public bool audioPlayed;

    public List<GameObject> monstersInRoom = new List<GameObject>();
    public List<GameObject> blockers = new List<GameObject>();

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("ScriptManager");
        rM = manager.GetComponent<RoomManager>();
    }

    private void Update()
    {
        if (rM.monsterCount <= 0)
        {
            
            foreach (GameObject block in blockers)
            {
                Destroy(block);
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !spawnDone)
        {
            rM.monsterCount = monstersInRoom.Count;
            spawnDone = true;
            rM.roomBlocked.Play();
            foreach (GameObject door in doorWays)
            {
                if (door.GetComponent<DoorwaySc>().isConnected)
                {
                    blockers.Add(Instantiate(rM.doorBlock, door.transform));
                    
                }
            }
            foreach (GameObject monster in monstersInRoom)
            {
                monster.SetActive(true);
            }
        }
    }

}
