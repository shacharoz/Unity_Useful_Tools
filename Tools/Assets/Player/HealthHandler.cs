using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthHandler : MonoBehaviour {
    
    public int Strikes;

    private int _currentStrikes;
    
    public UnityEvent OnHealthEnd;


    public void UpdateHealth(int strikes)
    {
        _currentStrikes += strikes;

        if (_currentStrikes <= 0)
        {
            OnHealthEnd.Invoke();
        }
    }

    public void ResetHealth()
    {
        _currentStrikes = Strikes;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
