using System.Collections.Generic;
using UnityEngine;

namespace WizardOzTools
{
    public class InputKeyActivator : MonoBehaviour
    {
        public List<EventItem> Events;

        void Update()
        {
            foreach (EventItem item in Events)
            {
                if (Input.GetKeyDown(item.ActivationKey))
                {
                    item.Activate.Invoke();
                }
            }
        }
    }

    [System.Serializable]
    public class EventItem
    {
        public string EventTitle;
        public KeyCode ActivationKey;
        public UnityEngine.Events.UnityEvent Activate;
    }
}