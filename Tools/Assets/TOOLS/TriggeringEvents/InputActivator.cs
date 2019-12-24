using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputActivator : MonoBehaviour
{
    public List<EventItem> Events;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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