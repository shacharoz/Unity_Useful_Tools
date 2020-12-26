using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotGrabber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TakeScreenshot();
    }

    public void TakeScreenshot()
    {
        string pathToFile = System.IO.Path.Combine(Application.temporaryCachePath, string.Format("Screenshot_{0:yyyy-MM-dd_hh-mm-ss-tt}_{1}.png", System.DateTime.Now, UnityEditor.GUID.Generate()));
        Microsoft.MixedReality.Toolkit.Utilities.Editor.ScreenshotUtility.CaptureScreenshot(pathToFile,10);
    }
}
