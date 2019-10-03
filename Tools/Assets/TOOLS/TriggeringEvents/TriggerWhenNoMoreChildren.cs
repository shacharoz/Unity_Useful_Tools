using UnityEngine;
using UnityEngine.Events;

public class TriggerWhenNoMoreChildren : MonoBehaviour {

    public UnityEngine.Events.UnityEvent NoMoreChildren;

    private bool triggeredOnce;

	// Use this for initialization
	void Start () {
        triggeredOnce = false;	
	}
	
	// Update is called once per frame
	void Update () {
		if (!triggeredOnce && GetComponent<Transform>().childCount == 0)
        {
            NoMoreChildren.Invoke();
            triggeredOnce = true;


            Debug.Log("game over");
        }
	}


    public void CheckNow()
    {
        if (GetComponent<Transform>().childCount == 0)
        {
            Debug.Log("game over");
        }
    }
}
