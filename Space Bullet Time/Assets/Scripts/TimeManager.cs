using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
	/*
	This class control all aspects of Time in the game, speed of Bullets as well as speed of the Explosion, player and enemies
	*/
	[SerializeField]
	private float bulletTime = 1f;// it is 1 if the players moves and 0 if he dont
	private float minimumBulletTime = 0.05f;
	private float bulletTimeDecrease = 0.3f;
	
	
    public void SetBulletTime(float _bulletTime){
		bulletTime = _bulletTime;
	}
	public float GetBulletTime(){
		return bulletTime;
	}

    // Update is called once per frame
    void Update()
    {
		
        // the minimum of the Bullet time will always be minimum
		if(bulletTime > minimumBulletTime){
			bulletTime -= bulletTimeDecrease;//decrease the bullet time per frame so it stops moving after a time the player moves
		}
		else bulletTime = minimumBulletTime;
		
		
    }
}
