using UnityEngine;
using UnityEngine.Events;

public class PlatformDetector : MonoBehaviour
{
    public UnityEvent OnPlatformAndroidDetected;
    public UnityEvent OnPlatformIosDetected;
    public UnityEvent OnPlatformPcDetected;

    void Start()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            OnPlatformIosDetected.Invoke();
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            OnPlatformAndroidDetected.Invoke();
        }
    }


}
