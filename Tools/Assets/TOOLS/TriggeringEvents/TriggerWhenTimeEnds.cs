using UnityEngine;

namespace WizardOzTools
{
    public class TriggerWhenTimeEnds : MonoBehaviour
    {
        public string description = "use this field to describe the trigger action";

        /// <summary>
        /// time to wait
        /// </summary>
        public int TimeInSeconds = 60;

        /// <summary>
        /// start the counter automatically or wait for an external function call
        /// </summary>
        public bool StartImmediately = false;

        /// <summary>
        /// event to call in the end of the count
        /// </summary>
        public UnityEngine.Events.UnityEvent OnTimeRunOut;

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
}