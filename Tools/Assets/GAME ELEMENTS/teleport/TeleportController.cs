using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    public Transform Enter;
    public Transform Exit;

    public UnityEngine.Events.UnityEvent OnTeleportActivated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
