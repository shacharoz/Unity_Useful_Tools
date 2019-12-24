using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAppManager : MonoBehaviour
{
    /*
    private static DebugAppManager _instance = null;
    
    public static DebugAppManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DebugAppManager();
            }
            return _instance;
        }
    }
    */

    [Header("is it release version")]
    public bool IsRelease;

    internal bool UseOculus
    {
        get
        {
            return _useOculus;
        }
    }
    private bool _useOculus;


    [Header("Cameras")]
    public Transform OculusCamera;
    public Transform EditorCamera;

    [Header("Controls")]
    public bool IsUseHandControllers;

    internal bool UseHandControllers
    {
        get
        {
            return _useHandControllers;
        }
    }
    private bool _useHandControllers;


    // Start is called before the first frame update
    void Start()
    {
        _useOculus = IsRelease;
        _useHandControllers = IsUseHandControllers;


        //implement settings
        OculusCamera.gameObject.SetActive(_useOculus);
        EditorCamera.gameObject.SetActive(!_useOculus);
    }

    internal Transform PlayerTransform ()
    {
        return (_useOculus) ? OculusCamera : EditorCamera;
    }



    // Update is called once per frame
    void Update()
    {
        /*
        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote)
            && OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);

            OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.Touch)
        }*/
    }


    // touchpad tap 
    // OVRInput.Get(OVRInput.Button.PrimaryTouchpad).

}
