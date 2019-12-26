using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Text;
using System;


public class UDPWrapper : MonoBehaviour {
    public bool dontDestroyBetweenScenes;

    [Header("My Server Config")]
    public int internalPort = 50000;
    [Header("My Client Config")]
    public string externalIp = "10.0.0.33";
    public int externalPort = 50001;
    //private string externalPortStr;

   

    [Header("Properties")]
    public UDPReceive udpReciever;
    public External.UDPSend udpSender;
    public UDPCommunication UdpCom;

    [Tooltip("Send a message at Startup")]
    public bool sendPingAtStart = true;

    [Tooltip("Conten of Ping")]
    public string PingMessage = "hello";

    [Header("Expected Data Type")]
    [Tooltip("if the data is expected in bytes then choose false")]
    public bool isDataInStringType = true;


    [Header("DEBUG My Client")]
    //public string externalIpEditor = "127.0.0.1";
    //public int externalPortEditor = 50002;


    public bool debug = false;

    public System.Action<byte[]> onMainThreadData;

    private object qLock = new object();
    private Queue<byte[]> dataQ = new Queue<byte[]>();
    private const int MaxQSize = 1;
    private void Reset()
    {
        udpReciever = GetComponent<UDPReceive>();
        udpSender = GetComponent<External.UDPSend>();
        UdpCom = GetComponent<UDPCommunication>();
    }

    private void Awake()
    {
        if (dontDestroyBetweenScenes)
        {
            if (FindObjectsOfType(GetType()).Length > 1)
            {
                Destroy(gameObject);
#if !UNITY_WSA || UNITY_EDITOR
                UdpCom.enabled = false;
                udpSender.enabled = false;
                udpReciever.enabled = false;
#else
        UdpCom.enabled = false;
        udpSender.enabled = false;
        udpReciever.enabled = false;
#endif
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        //externalPortStr = externalPort.ToString();

        udpReciever.port = internalPort;
        udpReciever.onData += OnMessage;
        udpReciever.IsDataInStringType = isDataInStringType;

        udpSender.port = externalPort;
        udpSender.IP = externalIp;

        UdpCom.internalPort = internalPort.ToString();
        UdpCom.externalIP = externalIp;
        UdpCom.externalPort = externalPort.ToString();
        UdpCom.sendPingAtStart = false;
        UdpCom.udpEvent.AddListener(OnMessage);

#if !UNITY_WSA || UNITY_EDITOR
        UdpCom.enabled = false;
        udpSender.enabled = true;
        udpReciever.enabled = true;
#else
        UdpCom.enabled = true;
        udpSender.enabled = false;
        udpReciever.enabled = false;
#endif
    }

    IEnumerator Start()
    {

        if (sendPingAtStart)
        {
            Send(PingMessage);
        }
        if (debug)
        {
            if (isDataInStringType)
            {
                onMainThreadData += (data) => Debug.LogFormat(name + " Recieve >> {0}", Encoding.UTF8.GetString(data));
            }
            else
            {
                onMainThreadData += (data) =>
                {
                    Debug.Log(name + " Recieve >> ");
                    ArrayExtensions.printArrayValues(data);
                };
                
            }
        }
        yield return new WaitForSeconds(3);
        ready = true;
    }

    private void OnDestroy()
    {
            
        udpReciever.onData -= OnMessage;
        UdpCom.udpEvent.RemoveListener(OnMessage);
    }

    private Queue<byte[]> mainTQ = new Queue<byte[]>();
    private bool ready = false;
    private void Update()
    {
        try
        {
            if (dataQ.Count > 0)
            {
                lock (qLock)
                {
                    Queue<byte[]> tempQ = dataQ;
                    dataQ = mainTQ;
                    mainTQ = tempQ;
                }
            }
            if (onMainThreadData != null)
            {
                while (mainTQ.Count > 0)
                {
                    try
                    {
                        onMainThreadData(mainTQ.Dequeue());
                    }
                    catch (Exception e)
                    {
                        Debug.LogError("Specific q error with " + e);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("QError with " + e);
        }
        finally
        {
            mainTQ.Clear();
        }

    }
    //In different thread
    private void OnMessage(string arg0, string arg1, byte[] arg2)
    {
//#if !UNITY_WSA || UNITY_EDITOR
//        if (debug)
//        {
//            Debug.LogFormat("MSG {0}:{1} >> {2}", arg0, arg1, Encoding.UTF8.GetString(arg2));
//        }
//#endif
        lock (qLock)
        {
            if (dataQ.Count > MaxQSize) dataQ.Dequeue();
            dataQ.Enqueue(arg2);
        }
    }





    public void Send(string msg)
    {
        if (ready == false) return;
#if !UNITY_WSA || UNITY_EDITOR
        if (debug)
        {
            Debug.LogFormat(name + " Send >> {0} ", msg);
        }
#endif
#if !UNITY_WSA || UNITY_EDITOR
        System.Threading.ThreadPool.QueueUserWorkItem((a) => {
            udpSender.Send(Encoding.UTF8.GetBytes(msg));
        });
#else
        System.Threading.Tasks.Task.Run(() =>{
            UdpCom.SendUDPMessage(Encoding.UTF8.GetBytes(msg));
        });
#endif
        }

    public void Send(byte[] data)
    {
        if (ready == false) return;
#if !UNITY_WSA || UNITY_EDITOR
        if (debug)
        {
            Debug.LogFormat("Send >> {0} ", Encoding.UTF8.GetString(data));
        }
#endif

#if !UNITY_WSA || UNITY_EDITOR
        System.Threading.ThreadPool.QueueUserWorkItem((a) => {
            udpSender.Send(data);
        });
#else
        System.Threading.Tasks.Task.Run(() =>{
            UdpCom.SendUDPMessage(data);
 });
#endif
    }

}
