using UnityEngine;

namespace WizardOzTools
{
    public class KillAfter : MonoBehaviour
    {
        public UnityEngine.Events.UnityEvent OnKill;

        public float sequenceTime;
        private bool _isStarted;
        private float _startTime;

        public bool StartImmediately = false;

        void Start()
        {
            _isStarted = false;
            _startTime = 0;

            if (StartImmediately == true)
            {
                KillNow();
            }
        }

        void Update()
        {
            if (_isStarted == true)
            {
                if (Time.time - _startTime > sequenceTime)
                {
                    _isStarted = false;
                    KillEnded();
                }
            }
        }

        public void KillNow()
        {
            _startTime = Time.time;
            _isStarted = true;

            OnKill.Invoke();
        }

        public void KillEnded()
        {
            Destroy(this.gameObject);
        }
    }
}