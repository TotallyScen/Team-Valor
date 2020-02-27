using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private GameObject Manager;
    public List<GameObject> doors = new List<GameObject>();
    public GameObject doorPrefab;
    public int currentDoorIndex;
    public GameObject[] doorPoints;

    void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("ScriptManager");
        DoorSpawn();
    }

    private void Update()
    {
      
    }

    public void DoorSpawn()
    {
        foreach (GameObject doorway in doorPoints)
        {
            doors.Add(Instantiate(doorPrefab, doorPoints[currentDoorIndex].transform.position, doorPoints[currentDoorIndex].transform.rotation, transform));

           /* if (!Physics.Raycast(doorPoints[currentDoorIndex].transform.position, doorPoints[currentDoorIndex].transform.forward, rayLenght))
            {
                Manager.GetComponent<RoomManager>().StartCoroutine(Manager.GetComponent<RoomManager>().InstRoom(doorPoints[currentDoorIndex].transform));
            } */
                currentDoorIndex++;
        }


    }

}
