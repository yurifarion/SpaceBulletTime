using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
	[SerializeField]
	private float coolDown = 1f;
	[SerializeField]
	private GameObject bullet_prefab;
	private float forceOfShoot = 6f;
	
	private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
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
			
			//if you have horizontal and vertical choose horizontal
			if(horizontal != 0 && vertical != 0){
				_anim.SetFloat("Horizontal",Mathf.Abs(horizontal));
				_anim.SetFloat("Vertical",0);
			}
			else{
			_anim.SetFloat("Horizontal",Mathf.Abs(horizontal));
			_anim.SetFloat("Vertical",vertical);
			}
			FlipChar(horizontal);
			
			Vector3 directionOfShoot = new Vector3(horizontal,vertical,0);
			GameObject _bullet = Instantiate(bullet_prefab,transform.position + directionOfShoot*1.5f,transform.rotation);//create projetile in the position of the player
			
			//Add the main class to control the movement of the bullet and set it to the current Direction
			_bullet.AddComponent<BulletMovement>().SetBulletDirection(directionOfShoot);

		}
	}
	//Flip char in case of it going right
	 void FlipChar(float horizontal){
		//If horizontal is greater or lower than zero i flip the char
		bool result =  (horizontal>0 && horizontal!=0) ? true : false;
		GetComponent<SpriteRenderer>().flipX = result;
	}
    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
}
