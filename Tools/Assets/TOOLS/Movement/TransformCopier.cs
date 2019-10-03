using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformCopier : MonoBehaviour
{
    public Transform SourceTransform;
    public float OffsetForward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = SourceTransform.rotation;
        
        transform.SetPositionAndRotation(SourceTransform.position, SourceTransform.rotation);
        transform.Translate(Vector3.forward * OffsetForward);
    }
}
