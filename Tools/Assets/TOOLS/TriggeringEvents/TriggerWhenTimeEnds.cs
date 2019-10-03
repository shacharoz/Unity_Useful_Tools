using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWhenTimeEnds : MonoBehaviour {

    public int TimeInSeconds = 60;

    public UnityEngine.Events.UnityEvent OnTimeRunOut;

    private bool _isCountStarted;
    private float _startTime;

    public bool StartImmediately = false;

	// Use this for initialization
	void Start () {
        _isCountStarted = false;

        if (StartImmediately == true)
        {
            StartCountdown();
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (_isCountStarted == true)
        {
            if (Time.time - _startTime > TimeInSeconds)
            {
                _isCountStarted = false;
                OnTimeRunOut.Invoke();
            }
        }
	}

    public void StartCountdown()
    {
        _isCountStarted = true;
        _startTime = Time.time;
    }

    public void StopCountdown()
    {
        _isCountStarted = false;
    }
}
