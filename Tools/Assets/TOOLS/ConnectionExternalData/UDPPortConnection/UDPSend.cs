/*
 
    -----------------------
    UDP-Send
    -----------------------
    // [url]http://msdn.microsoft.com/de-de/library/bb979228.aspx#ID0E3BAC[/url]
   
    // > gesendetes unter
    // 127.0.0.1 : 8050 empfangen
   
    // nc -lu 127.0.0.1 8050
 
        // todo: shutdown thread at the end
*/
using UnityEngine;
using System.Collections;

using System;
using System.Text;

#if !UNITY_WSA || UNITY_EDITOR
using System.Net;
using System.Net.Sockets;
#endif

using System.Threading;

namespace External
{
    public class UDPSend : MonoBehaviour
    {
        private static int localPort;

        // prefs
        public string IP = "127.0.0.1";  // define in init
        public int port = 8051;  // define in init

#if !UNITY_WSA || UNITY_EDITOR

        // "connection" things
        IPEndPoint remoteEndPoint;
        UdpClient client;



        // start from unity3d
        public void Start()
        {
            init();
        }

        // OnGUI
        //void OnGUI()
        //{
        //    Rect rectObj = new Rect(40, 380, 200, 400);
        //    GUIStyle style = new GUIStyle();
        //    style.alignment = TextAnchor.UpperLeft;
        //    GUI.Box(rectObj, "# UDPSend-Data\n127.0.0.1 " + port + " #\n"
        //                + "shell> nc -lu 127.0.0.1  " + port + " \n"
        //            , style);

        //    // ------------------------
        //    // send it
        //    // ------------------------
        //    strMessage = GUI.TextField(new Rect(40, 420, 140, 20), strMessage);
        //    if (GUI.Button(new Rect(190, 420, 40, 20), "send"))
        //    {
        //        sendString(strMessage + "\n");
        //    }
        //}

        // init
        private void init()
        {
            // Endpunkt definieren, von dem die Nachrichten gesendet werden.
            //print("UDPSend.init()");

            // define

            // ----------------------------
            // Senden
            // ----------------------------
            remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
            client = new UdpClient();

            // status
            //print("Init Sending to " + IP + " : " + port);

        }
        private void OnDestroy()
        {
            if (client != null) { client.Close(); client = null; }
            //Debug.Log("EndSendClient");

        }
        public void Send(byte[] data)
        {
            
            client.Send(data, data.Length, remoteEndPoint);

        }
        public void Send(string text)
        {
            if (string.IsNullOrEmpty(text) == false)
            {

                // Daten mit der UTF8-Kodierung in das Binärformat kodieren.
                byte[] data = Encoding.UTF8.GetBytes(text);

                // Den Text zum Remote-Client senden.
                client.Send(data, data.Length, remoteEndPoint);
            }
        }

#else
        void Start(){}
        private void OnDestroy(){}

        public void Send(byte[] data)
        {
            throw new System.NotSupportedException("Not working outside of editor");
        }
        public void Send(string text)
        {
            throw new System.NotSupportedException("Not working outside of editor");
        }
#endif


    }
}