using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionControls : MonoBehaviour
{

    /**
     * POTENTIAL INTERACTIONS
     * 
     * 1. MOVEMENT
     *      - FLYING WITH ANIMATION (NO CONTROLS)
     *      - USER MOVE BY FOOT PHYSICAL
     *      - USER MOVE WITH JOYSTICK
     * 2. CHANGE LOOK 
     *      - USER TURN THE LOOK WITH JOYSTICK
     *      - USER TURN THE LOOK WITH WALKING PHYSICAL
     *      
     *      
     * 2. SELECTION OBJECT
     *      - BUTTONS ON REMOTE
     *      - ANALOG BUTTON ON REMOTE
     *      - COLLIDER / COLLISION
     *      - GAZE
     *         OVRGazePointer: connect it to the joint CenterEyeAnchor
     * 
     * 
     * 3. Grabbing Objects
     *      - Add Grabbable + rigidbody to the object
     *      - Add Grabber to the hand
     * 
     * 
     * **/


    public UnityEvent OnXButtonClick;
    public UnityEvent OnYButtonClick;
    public UnityEvent OnAButtonClick;
    public UnityEvent OnBButtonClick;

    public UnityEvent OnIndexLeftClick;
    private float _indexLeftValue;
    public float IndexLeftValue { get { return _indexLeftValue; } }
    public UnityEvent OnIndexRightClick;
    private float _indexRightValue;
    public float IndexRightValue { get { return _indexRightValue; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            OnAButtonClick.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            OnBButtonClick.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            OnXButtonClick.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.Y))
        {
            OnYButtonClick.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            _indexLeftValue = Random.Range(0.1f, 1f);
            OnIndexLeftClick.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            _indexRightValue = Random.Range(0.1f, 1f);
            OnIndexRightClick.Invoke();
        }
    }

    
}
