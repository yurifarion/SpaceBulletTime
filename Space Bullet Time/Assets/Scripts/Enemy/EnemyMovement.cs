using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	/*
	This class is responsable to make the movement of the Enemy using some basic artifial inteligence, 
	the player will be set as the target by default, the movement is based in CharacterController and 
	the physics are 3D using Box Collider
	
	*/
	private GameObject _target;
	private CharacterController _charControl;
	public float speed;
	public float enemy_life = 100;
	
	
    // Start is called before the first frame update
    void Start()
    {
		//set target as Player by tag
		_target = GameObject.FindGameObjectWithTag("Player");
		_charControl = GetComponent<CharacterController>();
        
    }
	void Move(Transform t){
		//We need to know if the target is up, down, in front or behind ur
		float horizontal = (transform.position.x > t.transform.position.x)?-1:1;
		float vertical = (transform.position.y > t.transform.position.y)?-1:1;
		
		//flip the enemy depending which way its going
		bool flip = (horizontal < 0);
		FlipX(flip);
		
		Vector3 dir = new Vector3(horizontal,vertical,0);
		
		_charControl.Move(dir * speed * Time.deltaTime);
	}
	//flip the sprite renderer as well as the collider or any other thing that need to be flipped
	void FlipX(bool flipx){
		GetComponent<SpriteRenderer>().flipX = flipx; //flip sprite
	}
    // Update is called once per frame
    void Update()
    {
        Move(_target.transform);
    }
}
