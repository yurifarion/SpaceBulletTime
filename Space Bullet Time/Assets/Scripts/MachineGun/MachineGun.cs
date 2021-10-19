using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
	/*
	Simple Machine Gun logic just to Showoff mechanics
	*/
	[SerializeField]
	private float coolDown = 1f;
	
	public float coolDownTimer = 1f;
	
	[SerializeField]
	private Vector3 shootDirection = new Vector3(1,0,0);
	
	[SerializeField]
	private GameObject bullet_prefab;
	
	// Time Manager
	private TimeManager _timemanager;
	
    // Start is called before the first frame update
    void Start()
    {
		_timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();	
        
    }
	//It will shoot until it dies with a coolDown on WaitForSeconds
	void Shoot(){
		 //Check cool down
		 coolDownTimer += Time.deltaTime * _timemanager.GetBulletTime();
		 
		 if(coolDownTimer >=  coolDown){//it means machine can shoot again 
			 coolDownTimer = 0;

			GameObject _bullet = Instantiate(bullet_prefab,transform.position + shootDirection*1.5f,transform.rotation);//create projetile in the position of the player
			//Add the main class to control the movement of the bullet and set it to the current Direction
			_bullet.AddComponent<BulletMovement>().SetBulletDirection(shootDirection);
			
		 }
	 }
    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
}
