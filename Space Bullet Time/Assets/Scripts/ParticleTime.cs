using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTime : MonoBehaviour
{
	// Time Manager
	private TimeManager _timemanager;
	private ParticleSystem _pSystem;
    // Start is called before the first frame update
    void Start()
    {
        _timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
		_pSystem = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
		//If we are on bullet time Pause Particle System
        var noise = _pSystem.noise;
			noise.strength = 0.5f * _timemanager.GetBulletTime();
    }
}
