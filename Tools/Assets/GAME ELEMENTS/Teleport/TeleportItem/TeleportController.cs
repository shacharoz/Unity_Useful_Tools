using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent OnTeleportActivated;

    public Transform Enter;
    public Transform Exit;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void OnPlayerEnter()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerTransform.gameObject.SetActive(false);

        playerTransform.position = Exit.position;
        playerTransform.gameObject.SetActive(true);
        OnTeleportActivated.Invoke();
    }
}
