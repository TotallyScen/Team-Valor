using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    /// <summary>
    /// final/escape room can be spawned on a random door that doesnt have a room
    /// check of a door has a room with a bool
    /// </summary>
    public GameObject[] roomPrefabs;

    public int maxRoomCount;
    public int currentRoomIndex;

    public Vector3 offset;
    private float rayLenght = 10;

    private Vector3 checkBox;
    public Vector3 checkSize;

    public List<GameObject> currentRooms = new List<GameObject>();
    public List<GameObject> newRooms = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        currentRooms.Add(GameObject.FindGameObjectWithTag("Start room"));
        foreach (GameObject door in currentRooms[currentRoomIndex].GetComponent<Room>().doorPoints)
        {
            if(!Physics.Raycast(door.transform.position, door.transform.forward, rayLenght))
            {
                print("egg");

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator InstRoom(Transform doorTR)
    {
        if (currentRoomIndex < maxRoomCount)
        {
            newRooms.Add(Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Length)], doorTR.position, transform.rotation, doorTR));
            newRooms[currentRoomIndex].transform.localPosition += offset;
            currentRoomIndex++;
            yield return new WaitForSeconds(3);
            
        }


        /*  public IEnumerator InstRoom(Transform doorTR)
          {
              if(currentRoomIndex < maxRoomCount)
              {
                  rooms.Add(Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Length)], doorTR.position, transform.rotation, doorTR));
                  rooms[currentRoomIndex].transform.localPosition += offset;
                  currentRoomIndex++;
                  yield return new WaitForSeconds(1);

              }
              else
              {
                  print("Room limit hit!!");
              } */
    }

   



}
