using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnKeyPressed : MonoBehaviour {

    public string description;
    public KeyCode Key;

    public UnityEngine.Events.UnityEvent OnInvoked;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(Key))
        {
            OnInvoked.Invoke();
        }		
	}
}
