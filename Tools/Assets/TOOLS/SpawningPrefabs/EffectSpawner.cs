using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : MonoBehaviour {

    public GameObject EffectPrefabToSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnNow()
    {
        Instantiate(EffectPrefabToSpawn, transform.position, transform.rotation);        
    }
}
