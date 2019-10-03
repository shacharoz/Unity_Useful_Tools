using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    private Transform realTarget;

    // Start is called before the first frame update
    void Start()
    {
        realTarget = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = Target.position + Offset;
        realTarget.position = p;
        transform.LookAt(realTarget);
    }
}
