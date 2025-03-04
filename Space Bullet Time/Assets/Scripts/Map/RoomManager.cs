﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
	//this class works in a way of randomize the enemies, objects and have control of how this room is linked to other rooms
	public GameObject downRoom;
	public GameObject upRoom;
	public GameObject leftRoom;
	public GameObject rightRoom;
	
	//this are all the possible gates that connect to other rooms, the room will only be available if we open a door to it
	public Gate gateDownRoom;
	public Gate gateUpRoom;
	public Gate gateLeftRoom;
	public Gate gateRightRoom;
	
	//Prefab of gate that only have one exit, in order to replace the current room with this.
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
	void Update(){
		//check if one of the gates is openned, if it is it will render the gate to it
		checkGates();
	}
	void checkGates(){
		//This will check every gate that is available and see if that's openned, if so it will show the room
		if(gateUpRoom!= null)if(gateUpRoom.isGateOpenned)upRoom.SetActive(true);
		if(gateDownRoom!= null)if(gateDownRoom.isGateOpenned)downRoom.SetActive(true);
		if(gateLeftRoom!= null)if(gateLeftRoom.isGateOpenned)leftRoom.SetActive(true);
		if(gateRightRoom!= null)if(gateRightRoom.isGateOpenned)rightRoom.SetActive(true);
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
				Debug.Log("Error, spawned a dead end ... Respawning ...");
				//We have a room on Left, and its the only one
				GameObject room;
				if(leftRoom != null){
					room = Instantiate(leftIsolatedRoomPrefab,transform.position,transform.rotation);
				//Create the connection of the object with each other with RoomManager
						room.GetComponent<RoomManager>().downRoom = downRoom;
						room.GetComponent<RoomManager>().upRoom = upRoom;
						room.GetComponent<RoomManager>().leftRoom = leftRoom;
						room.GetComponent<RoomManager>().rightRoom = rightRoom;
						
						//room.SetActive(false);//The room will be invisible until you open a door to it.
				}
				else if(downRoom != null){
					room = Instantiate(downIsolatedRoomPrefab,transform.position,transform.rotation);
				//Create the connection of the object with each other with RoomManager
						room.GetComponent<RoomManager>().downRoom = downRoom;
						room.GetComponent<RoomManager>().upRoom = upRoom;
						room.GetComponent<RoomManager>().leftRoom = leftRoom;
						room.GetComponent<RoomManager>().rightRoom = rightRoom;
						//room.SetActive(false);//The room will be invisible until you open a door to it.
				}
				else if(upRoom != null){
					room = Instantiate(upIsolatedRoomPrefab,transform.position,transform.rotation);
				//Create the connection of the object with each other with RoomManager
						room.GetComponent<RoomManager>().downRoom = downRoom;
						room.GetComponent<RoomManager>().upRoom = upRoom;
						room.GetComponent<RoomManager>().leftRoom = leftRoom;
						room.GetComponent<RoomManager>().rightRoom = rightRoom;
						//room.SetActive(false);//The room will be invisible until you open a door to it.
				}
				else if(rightRoom != null){
						room = Instantiate(rightIsolatedRoomPrefab,transform.position,transform.rotation);
						//Create the connection of the object with each other with RoomManager
						room.GetComponent<RoomManager>().downRoom = downRoom;
						room.GetComponent<RoomManager>().upRoom = upRoom;
						room.GetComponent<RoomManager>().leftRoom = leftRoom;
						room.GetComponent<RoomManager>().rightRoom = rightRoom;
						//room.SetActive(false);//The room will be invisible until you open a door to it.
				}
						
						
			}
			
		}
	}
    
}
