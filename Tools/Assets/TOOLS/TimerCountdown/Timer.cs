using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public UnityEngine.UI.Text timerTextField;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timerTextField.text = Time.time.ToString("00:00");
        //string.Format("{0:0.##}", 256.0);
    }
}
