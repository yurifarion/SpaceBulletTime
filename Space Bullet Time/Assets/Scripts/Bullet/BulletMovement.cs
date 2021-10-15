using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
	private CharacterController _charController;
	private Vector3 bulletDirection = Vector3.zero;
	private float bulletTime = 1f;
	private float speed = 10f;
	
	// Time Manager
	private TimeManager _timemanager;
	
	void Start(){
		_charController = gameObject.AddComponent<CharacterController>();
		_timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
	}
	
	public void SetBulletTime(float _bulletTime){
		bulletTime = _bulletTime;
	}
	//set bullet direction with a Vector3
    public void SetBulletDirection(Vector3 direction){
		bulletDirection = direction;
	}
	private void UptadeBulletTime(){
		bulletTime = _timemanager.GetBulletTime();
	}
    // Update is called once per frame
    void Update()
    {
		UptadeBulletTime();
		//movement of Bullet
		if(bulletDirection != Vector3.zero)_charController.Move(bulletDirection * Time.deltaTime * speed * bulletTime); // Apply movement only if its not zero
        
    }
}
