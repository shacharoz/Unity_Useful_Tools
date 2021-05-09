using UnityEngine;
using UnityEngine.Events;

public class InvokeAfterScreenActiveForSeconds : MonoBehaviour
{
    public int SecondsRangeMin;
    public int SecondsRangeMax;
    
    public bool AutoStart = false;
    public bool AutoContinueWhenFinish = false;

    private float timeCounter;
    private bool isCounting;
    private int timeToNextItem;

    public UnityEvent OnTimerFinished;


    void Start()
    {
        if (AutoStart) 
            StartTimerCount();
    }

    private void TimerFinished()
    {
        isCounting = false;
        OnTimerFinished.Invoke();

        if (AutoContinueWhenFinish)
            StartTimerCount();
    }

    public void StartTimerCount()
    {
        timeToNextItem = Random.Range(SecondsRangeMin, SecondsRangeMax);
        timeCounter = 0;
        isCounting = true;
    }

    private void Update()
    {
        if (isCounting == true)
        {
            timeCounter += Time.deltaTime;

            if (timeCounter >= timeToNextItem)
            {
                TimerFinished();
            }
        }
    }
}