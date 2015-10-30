using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generator : MonoBehaviour {

    public GameObject[] availableRooms;

    public List<GameObject> currentRooms;

    private float screenWidthInPoints;

	// Use this for initialization
	void Start () {
        float height = 2.0f * Camera.main.orthographicSize;
        screenWidthInPoints = height * Camera.main.aspect;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    
	}

    void AddRoom(float farhtestRoomEndX)
    {
        //1
        int randomRoomIndex = Random.Range(0, availableRooms.Length);

        //2
        GameObject room = Instantiate(availableRooms[randomRoomIndex]);

        //3
        float roomWidth = room.transform.FindChild("floor").localScale.x;

        //4
        float roomCenter = farhtestRoomEndX + roomWidth * 0.5f;

        //5
        room.transform.position = new Vector3(roomCenter, 0, 0);

        //6
        currentRooms.Add(room);
    }
}
