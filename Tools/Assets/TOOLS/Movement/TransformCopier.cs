using UnityEngine;

public class TransformCopier : MonoBehaviour
{
    public Transform SourceTransform;
    public float OffsetForward;

    public bool UseContinuousMode = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UseContinuousMode == false) return;

        transform.rotation = SourceTransform.rotation;
        transform.SetPositionAndRotation(SourceTransform.position, SourceTransform.rotation);
        transform.Translate(Vector3.forward * OffsetForward);
    }

    public void CopyNow()
    {
        transform.position = SourceTransform.position;
        transform.Translate(Vector3.forward * OffsetForward);
    }
}
