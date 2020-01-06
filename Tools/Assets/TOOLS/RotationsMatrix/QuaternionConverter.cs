using UnityEngine;

public class QuaternionConverter : MonoBehaviour {
    

    public float QW;
    public float QX;
    public float QY;
    public float QZ;

    public Transform target;

    // Use this for initialization
    void Start () {
		if (target == null)
        {
            target = transform;
        }
	}
	
	// Update is called once per frame
	void Update () {

        Quaternion q = Quaternion.identity;
        q.x = QX;
        q.y = QY;
        q.z = QZ;
        q.w = QW;

        target.localRotation = q;
        
	}
}
