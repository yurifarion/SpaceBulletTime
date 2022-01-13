using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
	public bool isGateLocked = true;
	public bool isGateOpenned = false;
	private bool isPlayerInGateArea = false;// we use this variable to check it with the input E button in the Update

	//Lights of closed and open - purple closed and green open
	private GameObject _lightDislocked;
	private GameObject _lightLocked;
	
	void Start(){
		//find lights in the child transform of this object
		_lightLocked = transform.Find("Gate_LightClosed").gameObject;
		_lightDislocked = transform.Find("Gate_LightOpen").gameObject;
		
		
		//Will change the color in the first frame requesting the initial booleans isGateLocked and isGateOpenned
		if(isGateLocked){
			_lightDislocked.SetActive(false);
			_lightLocked.SetActive(true);
		}
		else{
			_lightDislocked.SetActive(true);
			_lightLocked.SetActive(false);
		}
		
	}
	void Awake(){
		
	}
	/*this fucntion search for a gate close to its gate, then if this gate is open it will open itself, 
	it prevents the player to get stuck with one door open and the other closed*/
	void DetectNeighborGate(){
		
		RaycastHit hit;
		// Does the ray intersect any gate excluding its own gate in down direction
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 10))
        {
				Debug.Log(gameObject.name+"Boom"+hit.transform.gameObject.name+hit.transform.gameObject.tag);
			   Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
            //it will check if the other gate is open, if it is, it will unlock and open its gate
			//since it will get the collider of the door of the gate, it will need to access the parente to get to the Class Gate info
			if(hit.transform.gameObject.tag == "Gate"){// it will get other objects that are not for our interest, so lets filter to what have gate tags
				
				if(hit.transform.gameObject.GetComponent<Gate>().isGateOpenned && !isGateOpenned){
					
					isGateLocked = false;
					OpenGate();
				}
			}
			
        }
		else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);
            
        }
		 if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, 10))
        {
			   Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
            //it will check if the other gate is open, if it is, it will unlock and open its gate
			//since it will get the collider of the door of the gate, it will need to access the parente to get to the Class Gate info
			if(hit.transform.gameObject.tag == "Gate"){// it will get other objects that are not for our interest, so lets filter to what have gate tags
				Debug.Log("Boom");
				if(hit.transform.gameObject.GetComponent<Gate>().isGateOpenned && !isGateOpenned){
					
					isGateLocked = false;
					OpenGate();
				}
			}
			
        }
		else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 1000, Color.white);
            
        }
		
		
		
		
	}
	void Update(){
		if(Input.GetKeyDown(KeyCode.E) && isPlayerInGateArea){
				OpenGate();
			}
			//if it is not openned yet check if it is open on the other side everyframe
			if(!isGateOpenned)DetectNeighborGate();
	}
	
	public void OpenGate(){
		isGateOpenned = true;
		gameObject.GetComponent<Animator>().SetBool("Open",true);
	}
	public void CloseGate(){
		isGateOpenned = false;
	}
	public void LockGate(){
		isGateLocked = true;
		_lightDislocked.SetActive(false);
		_lightLocked.SetActive(true);
	}
	public void DislockGate(){
		isGateLocked = false;
		_lightDislocked.SetActive(true);
		_lightLocked.SetActive(false);
	}
	
	//trigger to know if the player is standing in front of the gate
	private void OnTriggerEnter(Collider other)
    {
		// In order to be able to open it this door need to be unlocked and closed
        if(other.gameObject.tag == "Player" && !isGateLocked && !isGateOpenned){
			// in this case the gate is open so we can show our "open gate" message with UIManager
			UIManager _uiman = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIManager>();
			_uiman.ShowMessage("Press [E] to open the gate");
			isPlayerInGateArea = true;
		}
    }
	private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player"){
			// in this case the gate is open so we can show our "open gate" message with UIManager
			UIManager _uiman = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIManager>();
			_uiman.HideMessage();
			isPlayerInGateArea = false;
		}
    }
    
}
