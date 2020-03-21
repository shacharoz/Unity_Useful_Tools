using UnityEngine;

namespace WizardOzTools
{
    public class TriggerWhenNoMoreChildren : MonoBehaviour
    {
        public UnityEngine.Events.UnityEvent NoMoreChildren;

        private bool triggeredOnce;

        void Start()
        {
            triggeredOnce = false;
        }

        void Update()
        {
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
}