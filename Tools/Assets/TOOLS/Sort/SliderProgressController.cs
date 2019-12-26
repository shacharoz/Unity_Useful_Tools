using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderProgressController : MonoBehaviour {

    public List<Image> states;

    public int maxValue = 1;
    private float _precentagePerState;

	// Use this for initialization
	void Start () {
        _precentagePerState = maxValue / states.Count;       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value">should be from 0 to maxValue</param>
    public void GetProgressStatus(float value)
    {
        int index = Mathf.FloorToInt(value / _precentagePerState);

        for (int i = 0; i < states.Count; i++)
        {
            if (i <= index)
            {
                states[i].gameObject.SetActive(true);
            }
            else
            {
                states[i].gameObject.SetActive(false);
            }
        }
    }
}
