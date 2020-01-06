using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionVisualizer : MonoBehaviour {

    public float QW;
    public float QX;
    public float QY;
    public float QZ;

    public Transform source;

    // Use this for initialization
    void Start () {
        if (source == null)
        {
            source = transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
        QX = source.rotation.x;
        QY = source.rotation.y;
        QZ = source.rotation.z;
        QW = source.rotation.w;
        
    }
}
