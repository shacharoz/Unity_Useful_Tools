using UnityEngine;

namespace WizardOzTools
{
    public class TriggerManagerBasic : MonoBehaviour
    {
        public string description = "use this field to describe the trigger action";
        
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
        public UnityEngine.Events.UnityEvent OnHit;

        private void OnTriggerEnter(Collider other)
        {
            if (TriggerType == ColliderType.Trigger_PassThrough && other.CompareTag(TargetObjectTagName))
                OnHit.Invoke();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (TriggerType == ColliderType.Collider_PhysicalWall && collision.gameObject.CompareTag(TargetObjectTagName))
                OnHit.Invoke();
        }

        public enum ColliderType
        {
            Trigger_PassThrough,
            Collider_PhysicalWall
        }
    }
}