using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
	//this class works in a way of randomize the enemies, objects and have control of how this room is linked to other rooms
	public GameObject downRoom;
	public GameObject upRoom;
	public GameObject leftRoom;
	public GameObject rightRoom;
	
	//Prefab of rooms that only have one exit, in order to replace the current room with this.
	public GameObject downIsolatedRoomPrefab;
	public GameObject upIsolatedRoomPrefab;
	public GameObject leftIsolatedRoomPrefab;
	public GameObject rightIsolatedRoomPrefab;
	
	public int connectedRooms = 0;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CheckConnectedRooms",0.4f);
	
    }
	void CheckConnectedRooms(){
		string typeOfRoom = this.gameObject.name;
		if(typeOfRoom != "Room AP"){//Room AP is the core room
			//it will remove the name Room and Clone from the string so it keeps only the information of connections
			typeOfRoom = typeOfRoom.Replace("Room","");
			typeOfRoom = typeOfRoom.Replace("(Clone)","");
			typeOfRoom = typeOfRoom.Replace("P","");
			typeOfRoom = typeOfRoom.Replace(" ","");
			
			
			if(downRoom != null) connectedRooms++;
			if(upRoom != null) connectedRooms++;
			if(leftRoom != null) connectedRooms++;
			if(rightRoom != null) connectedRooms++;
			
			/* if the room is a type of two exits and it doenst match 
			with the connected rooms, we probably have a door to nowhere 
			or a door to a wall, lets replace this by a prefab*/
			if(connectedRooms != typeOfRoom.Length){
				Debug.Log("Error, Replacing Room");
				switch(typeOfRoom){
					case "LD":
						GameObject room = Instantiate(leftIsolatedRoomPrefab,transform.position,transform.rotation);
						//Create the connection of the object with each other with RoomManager
						room.GetComponent<RoomManager>().upRoom = downRoom;
						room.GetComponent<RoomManager>().upRoom = upRoom;
						room.GetComponent<RoomManager>().upRoom = leftRoom;
						room.GetComponent<RoomManager>().upRoom = rightRoom;
						break;
					default:
					break;
				}
			}
			
		}
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
