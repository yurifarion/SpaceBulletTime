using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private float speed = 10f;

	private Animator _anim;
	private CharacterController _charController; // The movente will be based in Character Controller
	
	// Time Manager
	private TimeManager _timemanager;
    // Start is called before the first frame update
    void Start()
    {
		_anim = gameObject.GetComponent<Animator>();
		_anim.speed = 0;//Start scene without animation speed
       _charController = gameObject.AddComponent<CharacterController>();//it will add the Component if it doesnt already have it 
	   _timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();	
	  
   }
	//Make the Player move with the keyboard
	void Move(){
		float horizontal = Input.GetAxis("Horizontal");//  A and D
		float vertical = Input.GetAxis("Vertical");//  W and S
		
		if(horizontal != 0 || vertical != 0){
			
			_anim.speed = 1;
			
			
			_timemanager.SetBulletTime(1f);
			Vector3 movement = new Vector3(horizontal,vertical,0);//Create Vector to be applied to the CharacterController
			_charController.Move(movement * Time.deltaTime * speed);
		}
		else{
			_anim.speed = 0.05f;
		}
	}
	
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
