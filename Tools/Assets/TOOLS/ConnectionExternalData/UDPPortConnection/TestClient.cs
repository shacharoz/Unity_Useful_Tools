using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;
using System.Net.Sockets;

using System.Linq;
using System.Text;
using System.Net;
using System.Threading;

public class TestClient : MonoBehaviour
{
    public StrEvent eventStr;

    [System.Serializable]
    public class StrEvent : UnityEngine.Events.UnityEvent<string> { }

    void Update()
    {
        eventStr.Invoke("Test");
    }
}