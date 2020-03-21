using UnityEngine;

public class Timer : MonoBehaviour {

    public UnityEngine.UI.Text timerTextField;

	void Start () {
		
	}
	
	void Update () {
        timerTextField.text = Time.time.ToString("00:00");
    }
}
