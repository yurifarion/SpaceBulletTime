using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	//Variable responsabel of Alerts that happen in the game
	public TextMeshPro uiMessage;
   
   
   public void ShowMessage(string message){
	   //set gameObject equal to true and then show message
	   uiMessage.gameObject.SetActive(true);
	   uiMessage.text = message;
   }
   public void HideMessage(){
	   //set gameObject equal to true and then show message
	   uiMessage.gameObject.SetActive(false);
	  
   }
}
