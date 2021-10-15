using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	[SerializeField]
	private float coolDown = 1f;
	[SerializeField]
	private GameObject bullet_prefab;
	private float forceOfShoot = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	//depending on the arrows it will shoot a projetile prefab in that direction
	void Shoot(){
		float horizontal = 0;
		float vertical = 0;
		
		/*
			Based on the Arrow key
			its created a realtion with horizontal and vertical
		*/
		if(Input.GetKeyDown(KeyCode.LeftArrow)) horizontal = -1;
		else if(Input.GetKeyDown(KeyCode.RightArrow)) horizontal = 1;
		else if(Input.GetKeyDown(KeyCode.UpArrow)) vertical = 1;
		else if(Input.GetKeyDown(KeyCode.DownArrow)) vertical = -1;
		
		if(horizontal != 0 || vertical != 0){
			Vector3 directionOfShoot = new Vector3(horizontal,vertical,0);
			GameObject _bullet = Instantiate(bullet_prefab,transform.position + directionOfShoot*1.5f,transform.rotation);//create projetile in the position of the player
			
			//Add the main class to control the movement of the bullet and set it to the current Direction
			_bullet.AddComponent<BulletMovement>().SetBulletDirection(directionOfShoot);

		}
	}
    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
}
