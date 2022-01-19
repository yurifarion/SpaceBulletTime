using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
	private RoomTemplate _roomtemplate;
	private int rand = 0;
	public bool spawned = false;
	
	// 1 -> will need a Down door
	// 2 -> will need a Up door
	// 3 -> will need a Left door
	// 4 -> will need a Right door
	void Awake(){
		//set the openingDirection based on the namespace
		
		if(gameObject.name == "SpawnPointDown")openingDirection = 1; 
		else if(gameObject.name == "SpawnPointUp")openingDirection = 2; 
		else if(gameObject.name == "SpawnPointLeft")openingDirection = 3; 
		else if(gameObject.name == "SpawnPointRight")openingDirection = 4; 
	}
	void Start(){
		_roomtemplate = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RoomTemplate>();
		Invoke("SpawnRoom",0.1f);
	}
	void SpawnRoom(){
		if(spawned == false){
			//Spawn a Down door
			if(openingDirection == 1){
				rand = Random.Range(0,_roomtemplate.downRooms.Length);
				GameObject room = Instantiate(_roomtemplate.downRooms[rand],transform.position,_roomtemplate.downRooms[rand].transform.rotation);
				//Create the connection of the object with each other with RoomManager
				transform.root.gameObject.GetComponent<RoomManager>().downRoom = room;
				room.GetComponent<RoomManager>().upRoom = transform.root.gameObject;
				_roomtemplate.AddRoom(room.GetComponent<RoomManager>());//it will add this room to the List of spawned rooms in Room Template
				//room.SetActive(false);//The room will be invisible until you open a door to it.
				
			}
			//Spawn a Up door
			else if(openingDirection == 2){
				rand = Random.Range(0,_roomtemplate.upRooms.Length);
				GameObject room = Instantiate(_roomtemplate.upRooms[rand],transform.position,_roomtemplate.upRooms[rand].transform.rotation);
				//Create the connection of the object with each other with RoomManager
				transform.root.gameObject.GetComponent<RoomManager>().upRoom = room;
				room.GetComponent<RoomManager>().downRoom = transform.root.gameObject;
				_roomtemplate.AddRoom(room.GetComponent<RoomManager>());//it will add this room to the List of spawned rooms in Room Template
				//room.SetActive(false);//The room will be invisible until you open a door to it.
				
			}
			//Spawn a Left door
			else if(openingDirection == 3){
				rand = Random.Range(0,_roomtemplate.leftRooms.Length);
				GameObject room = Instantiate(_roomtemplate.leftRooms[rand],transform.position,_roomtemplate.leftRooms[rand].transform.rotation);
				//Create the connection of the object with each other with RoomManager
				transform.root.gameObject.GetComponent<RoomManager>().leftRoom = room;
				room.GetComponent<RoomManager>().rightRoom = transform.root.gameObject;
				_roomtemplate.AddRoom(room.GetComponent<RoomManager>());//it will add this room to the List of spawned rooms in Room Template
				//room.SetActive(false);//The room will be invisible until you open a door to it.
				
			}
			//Spawn a Right door
			else if(openingDirection == 4){
				rand = Random.Range(0,_roomtemplate.rightRooms.Length);
				GameObject room = Instantiate(_roomtemplate.rightRooms[rand],transform.position,_roomtemplate.rightRooms[rand].transform.rotation);
				//Create the connection of the object with each other with RoomManager
				transform.root.gameObject.GetComponent<RoomManager>().rightRoom = room;
				room.GetComponent<RoomManager>().leftRoom = transform.root.gameObject;
				_roomtemplate.AddRoom(room.GetComponent<RoomManager>());//it will add this room to the List of spawned rooms in Room Template
				//room.SetActive(false);//The room will be invisible until you open a door to it.
			
			}
			spawned = true;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("SpawnPoint")){
			Destroy(gameObject);
			
		}
	}
}
