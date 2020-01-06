using UnityEngine;

public class TriggerWhenTimeEnds : MonoBehaviour
{
    public int TimeInSeconds = 60;
    public UnityEngine.Events.UnityEvent OnTimeRunOut;
    public bool StartImmediately = false;

    private bool _isCountStarted;
    private float _startTime;

    private void OnEnable()
    {
        _isCountStarted = false;

        if (StartImmediately == true)
        {
            StartCountdown();
        }
    }

    // Update is called once per frame
    void Update()
    {
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
