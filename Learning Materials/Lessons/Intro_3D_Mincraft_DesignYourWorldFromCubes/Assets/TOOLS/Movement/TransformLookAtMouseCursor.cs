
using UnityEngine;

public class TransformLookAtMouseCursor : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        RotateLeftRight();
        
    }

    /**
     * taken from http://holistic3d.com/tutorials/?ytid=blO039OzUZc
     * */
    private void RotateLeftRight()
    {
        // left-right rotation
        transform.localRotation = Quaternion.AngleAxis(Input.mousePosition.x, Vector3.up);

    }
}