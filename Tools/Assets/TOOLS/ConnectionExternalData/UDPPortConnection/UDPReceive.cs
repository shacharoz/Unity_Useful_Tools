/*
    -----------------------
    UDP-Receive (send to)
    -----------------------
    // [url]http://msdn.microsoft.com/de-de/library/bb979228.aspx#ID0E3BAC[/url]
   
    // > receive
    // 127.0.0.1 : 8051
   
    // send
    // nc -u 127.0.0.1 8051
*/
using UnityEngine;

using System;
using System.Text;

#if !UNITY_WSA || UNITY_EDITOR
using System.Net;
using System.Net.Sockets;
using System.Globalization;
#endif
using System.Threading;

public class UDPReceive : MonoBehaviour
{
    public bool debug;
    public bool active = true;
    public int port;

    public System.Action<string, string, byte[]> onData;

    [System.Serializable]
    public class EventString : UnityEngine.Events.UnityEvent<string> { }
    [System.Serializable]
    public class EventBytes : UnityEngine.Events.UnityEvent<byte[]> { }

    public EventString unityEventData;

    [Header("SHACHAR ADDITION")]
    public bool IsDataInStringType = true;

    public EventBytes unityEventBytesData;

    // infos
    private byte[] input;
   // private string lastReceivedUDPPacket = "";
   // private string infoData;

#if !UNITY_WSA || UNITY_EDITOR
    // receiving Thread
    private Thread receiveThread;
    private UdpClient client;
    // udpclient object

   

    //// start from shell
    //private static void Main()
    //{
    //    UDPReceive receiveObj = new UDPReceive();
    //    receiveObj.init();

    //    string text = "";
    //    do
    //    {
    //        text = Console.ReadLine();
    //    }
    //    while (!text.Equals("exit"));
    //}
    // start from unity3d
    public void Start()
    {

        init();
    }

    // OnGUI
    //void OnGUI()
    //{
    //    Rect rectObj = new Rect(40, 10, 200, 400);
    //    GUIStyle style = new GUIStyle();
    //    style.alignment = TextAnchor.UpperLeft;
    //    GUI.Box(rectObj, "# UDPReceive\n " + IP + "  " + port + " #\n"
    //                + "shell> nc -u  " + IP + " : " + port + " \n"
    //                + "\nLast Packet: \n" + lastReceivedUDPPacket
    //                + "\n\nAll Messages: \n" + allReceivedUDPPackets
    //            , style);
    //}

    // init
    private void init()
    {
        // Endpunkt definieren, von dem die Nachrichten gesendet werden.
        //print("UDPSend.init()");

        // status
        //print("Sending to " + IP + " : " + port);
        //print("Test-Sending to this Port: nc -u " + IP + "   " + port + "");


        // ----------------------------
        // Abhören
        // ----------------------------
        // Lokalen Endpunkt definieren (wo Nachrichten empfangen werden).
        // Einen neuen Thread für den Empfang eingehender Nachrichten erstellen.
        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();


        onData += OnDataArrived;
    }

    //private void OnApplicationQuit()
    //{
    //    EndClient();
    //}

    private void OnDestroy()
    {
        EndClient();
    }
    private void EndClient()
    {
        active = false;
        if (receiveThread != null) { receiveThread.Abort(); receiveThread = null; }
        if (client != null) { client.Close(); client = null; }
        Debug.Log("EndRecieveClient");
    }
    // receive thread

    // Handles IPv4 and IPv6 notation.
    private static IPEndPoint CreateIPEndPoint(string endPoint)
    {
        string[] ep = endPoint.Split(':');
        if (ep.Length < 2) throw new FormatException("Invalid endpoint format");
        IPAddress ip;
        if (ep.Length > 2)
        {
            if (!IPAddress.TryParse(string.Join(":", ep, 0, ep.Length - 1), out ip))
            {
                throw new FormatException("Invalid ip-adress");
            }
        }
        else
        {
            if (!IPAddress.TryParse(ep[0], out ip))
            {
                throw new FormatException("Invalid ip-adress");
            }
        }
        int port;
        if (!int.TryParse(ep[ep.Length - 1], NumberStyles.None, NumberFormatInfo.CurrentInfo, out port))
        {
            throw new FormatException("Invalid port");
        }
        return new IPEndPoint(ip, port);
    }

    private void ReceiveData()
    {
        //remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient(port);
        //IPEndPoint ip = CreateIPEndPoint(string.Format("{0}:{1}",IP,  port));
        IPEndPoint ip = new IPEndPoint(IPAddress.Any, port);
        while (active)
        {
            try
            {
                // Bytes empfangen.
                //if (debug) Debug.Log(DateTime.Now + " Start " + ip);

                input = client.Receive(ref ip);

                if (debug)
                {
                    if (IsDataInStringType)
                    {
                        string text = Encoding.UTF8.GetString(input);
                        Debug.Log(ip.Address + " >> " + text);
                        //lastReceivedUDPPacket = text;
                        //infoData = DateTime.Now + " End";
                    }
                    else
                    {
                        //meaning data is in bytes
                        ArrayExtensions.printArrayValues(input);
                    }
                }

                if (onData != null) onData(ip.Address.ToString(), ip.Port.ToString(), input);

                if (IsDataInStringType)
                {
                    unityEventData.Invoke(Encoding.UTF8.GetString(input));
                }
                else
                {
                    unityEventBytesData.Invoke(input);
                }
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
        client.Close();
    }

#else
    void Start(){}
    void OnDestroy(){}
#endif


    private void OnDataArrived (string s1, string s2, byte[] info)
    {
        if (info.Length > 4)
        {
            //SEND DATA TO PARSER! info
        }
    }


}
