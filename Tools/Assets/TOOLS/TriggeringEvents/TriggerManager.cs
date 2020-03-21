using System.Collections.Generic;
using UnityEngine;

namespace WizardOzTools
{
    public class TriggerManager : MonoBehaviour
    {
        public List<TriggerEventItem> events;

        private void OnTriggerEnter(Collider other)
        {
            foreach (TriggerEventItem te in events)
            {
                if (te.TriggerType == TriggerEventItem.ColliderType.Trigger_PassThrough 
                    && other.CompareTag(te.TargetObjectTagName))
                {
                    te.Activate.Invoke();
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            foreach (TriggerEventItem te in events)
            {
                if (te.TriggerType == TriggerEventItem.ColliderType.Collider_PhysicalWall 
                    && collision.gameObject.CompareTag(te.TargetObjectTagName))
                {
                    te.Activate.Invoke();
                }
            }
        }
    }

    [System.Serializable]
    public class TriggerEventItem
    {
        public string EventTitle;

        /// <summary>
        /// does it notify on a trigger or a physical collider
        /// </summary>
        public ColliderType TriggerType;

        /// <summary>
        /// tag of the game object we trigger for
        /// </summary>
        public string TargetObjectTagName = "Add Target Tag Here";

        /// <summary>
        /// event to call in the end of the count
        /// </summary>
        public UnityEngine.Events.UnityEvent Activate;

        public enum ColliderType
        {
            Trigger_PassThrough,
            Collider_PhysicalWall
        }
    }
}