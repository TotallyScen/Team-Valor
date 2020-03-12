using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    //Prefabs
    public GameObject[] roomPrefabs;
    public GameObject doorBlock;
    public GameObject finalRoom;
    public GameObject bossDoor;

    //Counters
    public int maxRoomCount;
    public int currentRoomIndex;
    private int currNewRoomIndex;
    private int totalRooms;

    //Spawn info
    public Vector3 offset;
    public float rayLenght;
    private RaycastHit hit;
    private GameObject finalDoorway;

    //Ref info
    public GameObject loadingUI;
    private GameObject player;

    //Lists
    public List<GameObject> currentRooms = new List<GameObject>();
    public List<GameObject> newRooms = new List<GameObject>();
    public List<GameObject> emptyDoorWays = new List<GameObject>();
    public List<GameObject> totalRoomList = new List<GameObject>();
   
    //Bools
    private bool isGen = true;
    private bool hasFinalRoom = false;
    public bool isFinished;


    // Start is called before the first frame update
    void Start()
    {
        loadingUI.SetActive(true); //dit is zodat ik de ui uit kan hebben staan terwijl ik in de scene werk zonder dat er een probleem komt als ik em niet aanzet
        StartCoroutine(InstRoom());
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerBehaviour>().moveAllow = false;
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

        if (isFinished)
        {
            loadingUI.SetActive(false);
            player.GetComponent<PlayerBehaviour>().moveAllow = true;
        }
    }

    public IEnumerator InstRoom()
    {
        if (totalRooms <= maxRoomCount)
        {
            foreach (GameObject room in currentRooms)
            {
                foreach (GameObject door in room.GetComponent<Room>().doorRoomSpawners) 
                {
                    RoomSpawn(door);
                    yield return new WaitForSeconds(0.1f);
                }
            }
            ListsUpdate();
            isGen = false;
        }
        else
        {
            if (currentRoomIndex < totalRoomList.Count) //verkomt out of bound error
            {
                foreach (GameObject doorway in totalRoomList[currentRoomIndex].GetComponent<Room>().doorWays)
                {
                    if (Physics.Raycast(doorway.transform.position, doorway.transform.forward, out hit, 5))
                    {
                        if(hit.transform.tag == "Door" && doorway.tag == "Door")
                        {
                            doorway.GetComponent<DoorwaySc>().isConnected = true;
                            if (!hit.transform.GetComponent<DoorwaySc>().isConnected)
                            {
                                DoorwayRemover();
                                yield return new WaitForSeconds(0.1f);
                            }
                        }
                        if (hit.transform.tag == "WallPiece" && doorway.tag == "Door")
                        {
                            doorway.GetComponent<DoorwaySc>().isConnected = true;
                            DoorwayRemover();
                            yield return new WaitForSeconds(0.1f);
                        }
                    }  
                    if (!Physics.Raycast(doorway.transform.position, doorway.transform.forward, 5)) // add layers if the final prefab blocks the ray
                    {
                        EmptyD(doorway);
                        yield return new WaitForSeconds(0.1f);
                    }
                    
                }
                currentRoomIndex++;
                isGen = false; 
            }
            else if (currentRoomIndex == totalRoomList.Count)
            {
                FinalRoomSpawn();
            }
            
        }

    }


    void RoomSpawn(GameObject door)
    {
        if (!Physics.Raycast(door.transform.position, door.transform.forward, rayLenght))
        {
            newRooms.Add(Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Length)], door.transform.position, transform.rotation, door.transform));
            newRooms[currNewRoomIndex].transform.localPosition += offset;
            currNewRoomIndex++;
            totalRooms++;
        }
    }

    void ListsUpdate()
    {
        currentRooms.Clear();
        for (int i = 0; i < newRooms.Count; i++)
        {
            GameObject room = newRooms[i];
            currentRooms.Add(room);
            totalRoomList.Add(room);
        }
        currentRoomIndex = 0;
        currNewRoomIndex = 0;
        newRooms.Clear();
    }

    void DoorwayRemover()
    {
        hit.transform.gameObject.SetActive(false);
    }
    
    void EmptyD(GameObject doorway)
    {
        emptyDoorWays.Add(doorway);
        if (doorway.tag != "WallPiece")
        {
            Instantiate(doorBlock, doorway.transform.position, doorway.transform.rotation, doorway.transform);
        }

    }

    void FinalRoomSpawn()
    {
        finalDoorway = emptyDoorWays[Random.Range(0, emptyDoorWays.Count)];
        if (!hasFinalRoom)
        {
            hasFinalRoom = true;
            totalRoomList.Add(Instantiate(finalRoom, finalDoorway.transform.position, finalDoorway.transform.rotation, finalDoorway.transform));
            totalRooms++;
            totalRoomList[totalRooms].transform.localPosition += offset;

            foreach (GameObject door in totalRoomList[totalRooms].GetComponent<Room>().doorWays)
            {
                if (Physics.Raycast(door.transform.position, door.transform.forward, out hit, 5))
                {
                    totalRoomList[totalRooms].transform.SetParent(totalRoomList[0].transform, true);
                    DoorwayRemover();
                    Instantiate(bossDoor, door.transform.position, door.transform.rotation, totalRoomList[totalRooms].transform);
                    Destroy(door);
                }
            }
            isFinished = true;
        }
    }



}
