using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
	[SerializeField]
	private bool isGateLocked = true;
	[SerializeField]
	private bool isGateOpenned = false;


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
	public void OpenGate(){
		isGateOpenned = true;
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
        if(other.gameObject.tag == "Player" && !isGateLocked){
			// in this case the gate is open so we can show our "open gate" message with UIManager
			UIManager _uiman = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIManager>();
			_uiman.ShowMessage("Press [E] to open the gate");
		}
    }
	private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player"){
			// in this case the gate is open so we can show our "open gate" message with UIManager
			UIManager _uiman = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIManager>();
			_uiman.HideMessage();
		}
    }
    
}
