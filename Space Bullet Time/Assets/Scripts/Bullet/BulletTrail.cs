using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour
{
	[SerializeField]
	private float speedOfFall;
	public float floorDeath = -1f; //if the particle fall this amount it will be destroyed
	public float tempFloor = 0;
	public Vector3 originalPos;
	
	// Time Manager
	private TimeManager _timemanager;
    // Start is called before the first frame update
    void Start()
    {
		originalPos = transform.position;
        _timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		transform.position += new Vector3(0,-0.01f*speedOfFall*_timemanager.GetBulletTime(),0);
		tempFloor += -0.01f*speedOfFall*_timemanager.GetBulletTime(); //accumulated distance
		//if is its higher than the floorDeath it will destroy the gameObject
		if(tempFloor < floorDeath){
			Destroy(this.gameObject);
		}
    }
}
