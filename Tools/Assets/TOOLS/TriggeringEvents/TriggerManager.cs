using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{

    public bool IsTrigger;
    public string TargetObjectTagName = "Target";
    

    public UnityEngine.Events.UnityEvent OnHit;


    private void OnTriggerEnter(Collider other)
    {
        if (IsTrigger && other.tag == TargetObjectTagName)
            OnHit.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!IsTrigger && collision.gameObject.tag == TargetObjectTagName)
            OnHit.Invoke();
    }
    


    // Start is called before the first frame update
    void Start()
    {
        
    }
    
}
