using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public GameObject[] roomPrefabs;

    public int maxRoomCount;
    public int currentRoomIndex;
    public int currNewRoomIndex;
    public int totalRooms;

    public Vector3 offset;
    private float rayLenght = 10;

    private Vector3 checkBox;
    public Vector3 checkSize;

    public List<GameObject> currentRooms = new List<GameObject>();
    public List<GameObject> newRooms = new List<GameObject>();
    public List<GameObject> emptyDoorWays = new List<GameObject>();

    private bool isGen = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InstRoom());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGen) // add loading screen
        {
            StopCoroutine(InstRoom());
            StartCoroutine(InstRoom());
            isGen = true;
        }
    }

    public IEnumerator InstRoom()
    {
        // Bij spawn room:
        // Check voor elke doorway:
        // Als raak == deur -> is cur doorway wall, dan kill wall. Is cur doorway door dan kill door.
        // als raak muur -> is curdoorway wall, doe niks (of kill de andere wall, blijft gesloten), is curdoorway deur -> kill the wall.
        if (totalRooms <= maxRoomCount)
        {
            foreach (GameObject room in currentRooms)
            {
                foreach (GameObject door in currentRooms[currentRoomIndex].GetComponent<Room>().doorRoomSpawners)
                {
                    if (!Physics.Raycast(door.transform.position, door.transform.forward, rayLenght))
                    {
                       
                        newRooms.Add(Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Length)], door.transform.position, transform.rotation, door.transform));
                        newRooms[currNewRoomIndex].transform.localPosition += offset;
                        currNewRoomIndex++;
                        totalRooms++;
                        yield return new WaitForSeconds(0.1f);
                    }
                }
                currentRoomIndex++;
            }
            currentRooms.Clear();
            for (int i = 0; i < newRooms.Count; i++)
            {
                GameObject room = newRooms[i];
                currentRooms.Add(room);
            }
            currentRoomIndex = 0;
            currNewRoomIndex = 0;
            newRooms.Clear();
            isGen = false;
        }

    }





}
