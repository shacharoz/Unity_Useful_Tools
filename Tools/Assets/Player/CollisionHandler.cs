using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour {


    [Header("Obstacle")]
    public string ObstacleTagName;
    public UnityEvent OnCollideObstacle;

    [Header("Pickup")]
    public string PickupTagName;
    public UnityEvent OnCollidePickup;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == ObstacleTagName)
        {
            Debug.Log(" I HIT OBSTACLE :) ");

            OnCollideObstacle.Invoke();
        }


        //collecting (hitting) a pickup
        if (other.tag == PickupTagName)
        {
            Debug.Log(" I HIT PICKUP :) ");

            OnCollidePickup.Invoke();
        }
    }
}
