using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject PrefabToSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnNow()
    {
        Instantiate(PrefabToSpawn, transform.position, transform.rotation);        
    }
    public void SpawnNow(Transform here)
    {
        Instantiate(PrefabToSpawn, here.position, here.rotation);
    }
}
