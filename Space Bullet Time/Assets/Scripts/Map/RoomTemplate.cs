using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{
	// It will save and organize all rooms types that i have, so it will be easier to select which will be on the generation
	public GameObject[] downRooms;
	public GameObject[] upRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;
	
	//this array will have all rooms that are spawned in the scene
	public List<RoomManager> spawnedRooms = new List<RoomManager>();
	
	//Check if all rooms were spawned
	private float timeLimit = 0.50f;//this is the Time out of the interval from each room spawn
	private float timer = 0.00f;//actual timer
	private bool allRoomSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;//Startcounting the timer
		if(timer >= timeLimit && !allRoomSpawned){
			Debug.Log("TIMEOUT"); // it means that probably the map construction ended
			allRoomSpawned = true;
			DisactivateAllRooms();
		}
		
    }
	//it will disactivate all rooms so they appear visible only if we open the door
	void DisactivateAllRooms(){
		if(allRoomSpawned) {
			foreach(RoomManager n in spawnedRooms){
				n.gameObject.SetActive(false);
			}
		}
	}
	// Adds room to the list
	public void AddRoom(RoomManager room){
		spawnedRooms.Add(room);
		timer = 0;
	}
}
