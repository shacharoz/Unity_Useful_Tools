using UnityEngine;
using UnityEngine.Events;

public class LongPressGestureDetector : MonoBehaviour
{
    public UnityEvent OnLongPress;
    public float TimeUntilLongPressDetected = 1f;

    private float start_time;
    private bool detectionInProgress;

    void Start()
    {
        detectionInProgress = false;
    }

    void Update()
    {
        if (detectionInProgress)
        {
            if (Time.time - start_time > TimeUntilLongPressDetected)
            {
                detectionInProgress = false;

                OnLongPress.Invoke();

                //Debug.Log("long pressed "+ gameObject.name);
            }
        }
    }

    public void PointerDown()
    {
        //Debug.Log("pointer down ");
        
        //start counting long press counter
        start_time = Time.time;
        detectionInProgress = true;
    }
    public void PointerUpOrExit()
    {
        //Debug.Log("pointer exit or up");

        //stop timer if not finished
        detectionInProgress = false;
    }
}