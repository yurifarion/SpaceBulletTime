using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedCreator : MonoBehaviour
{
	public int seed = 0;//Seed of the map
	public bool isSeedRandom = true;// If seed is random its going to replace for a random number
    // Start is called before the first frame update
    void Awake()
    {
        if(isSeedRandom)seed = Random.Range(0,99999); // set a random number if its necessary
		
		Random.InitState(seed);//Set the procedual random from seed
    }
	

}
