using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDesignManager : MonoBehaviour {

    [System.Serializable]
    public class LevelSpawnProperties
    {
        public GameObject levelPrefab;
    }

    public List<LevelSpawnProperties> LevelDesignProperties;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
