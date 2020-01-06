using System.Collections.Generic;
using UnityEngine;

public class MultiTriggerManager : MonoBehaviour
{
    public List<TriggerEventItem> events;

    private void OnTriggerEnter(Collider other)
    {
        foreach (TriggerEventItem te in events)
        {
            if (te.IsTrigger && other.tag == te.TargetObjectTagName)
            {
                te.Activate.Invoke();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (TriggerEventItem te in events)
        {
            if (te.IsTrigger == false && collision.gameObject.tag == te.TargetObjectTagName)
            {
                te.Activate.Invoke();
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }
}

[System.Serializable]
public class TriggerEventItem
{
    public string EventTitle;
    public bool IsTrigger;
    public string TargetObjectTagName = "Target";
    public UnityEngine.Events.UnityEvent Activate;
}
