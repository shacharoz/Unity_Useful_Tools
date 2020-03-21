using UnityEngine;

namespace WizardOzTools
{
    public class TriggerManager : MonoBehaviour
    {
        public string description = "use this field to describe the trigger action";
        public ColliderType TriggerType;
        public string TargetObjectTagName = "Add Target Tag Here";
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