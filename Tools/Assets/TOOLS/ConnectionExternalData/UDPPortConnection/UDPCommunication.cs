using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.Events;

#if UNITY_WSA && !UNITY_EDITOR
using Windows.Networking.Sockets;
using Windows.Networking.Connectivity;
using Windows.Networking;
#endif

[System.Serializable]
public class UDPMessageEvent : UnityEvent<string, string, byte[]>//IP,Port/data
{

}

public class UDPCommunication : MonoBehaviour
{
    [Tooltip("port to listen for incoming data")]
    public string internalPort = "12345";

    [Tooltip("IP-Address for sending")]
    public string externalIP = "192.168.17.110";

    [Tooltip("Port for sending")]
    public string externalPort = "12346";

    [Tooltip("Send a message at Startup")]
    public bool sendPingAtStart = true;

    [Tooltip("Conten of Ping")]
    public string PingMessage = "hello";

    [Tooltip("Function to invoke at incoming packet")]
    public UDPMessageEvent udpEvent = null;

    public bool debug, debugError;

   // private readonly Queue<Action> ExecuteOnMainThread = new Queue<Action>();

    public void Awake()
    {
        // base.Awake();
        if (udpEvent == null)
        {
            udpEvent = new UDPMessageEvent();
        }
    }
#if UNITY_WSA && !UNITY_EDITOR

    //we've got a message (data[]) from (host) in case of not assigned an event
    void UDPMessageReceived(string host, string port, byte[] data)
    {
    if(debug)
        Debug.Log("GOT MESSAGE FROM: " + host + " on port " + port + " " + data.Length.ToString() + " bytes ");
    }

  
    public async void SendUDPMessage(byte[] data)
    {
        await _SendUDPMessage(externalIP, externalPort, data);
    }

    //Send an UDP-Packet
    public async void SendUDPMessage(string HostIP, string HostPort, byte[] data)
    {
        await _SendUDPMessage(HostIP, HostPort, data);
    }



    DatagramSocket socket;

    async void Start()
    {
        Debug.Log("UDP COM start");
        //if (udpEvent == null)
        //{
        //    udpEvent = new UDPMessageEvent();
        //    udpEvent.AddListener(UDPMessageReceived);
        //}


        if(debug)Debug.Log("Waiting for a connection...");

        socket = new DatagramSocket();
        socket.MessageReceived += Socket_MessageReceived;

        HostName IP = null;
        try
        {
            var icp = NetworkInformation.GetInternetConnectionProfile();

            IP = Windows.Networking.Connectivity.NetworkInformation.GetHostNames()
            .SingleOrDefault(
                hn =>
                    hn.IPInformation?.NetworkAdapter != null && hn.IPInformation.NetworkAdapter.NetworkAdapterId
                    == icp.NetworkAdapter.NetworkAdapterId);

            await socket.BindEndpointAsync(IP, internalPort);
        }
        catch (Exception e)
        {
    if(debugError){
            Debug.Log(e.ToString());
            Debug.Log(SocketError.GetStatus(e.HResult).ToString());
    }
            return;
        }

        //if (sendPingAtStart)
        //    SendUDPMessage(externalIP, externalPort, Encoding.UTF8.GetBytes(PingMessage));

    }
    



    private async System.Threading.Tasks.Task _SendUDPMessage(string externalIP, string externalPort, byte[] data)
    {
        using (var stream = await socket.GetOutputStreamAsync(new Windows.Networking.HostName(externalIP), externalPort))
        {
            using (var writer = new Windows.Storage.Streams.DataWriter(stream))
            {
                writer.WriteBytes(data);
                await writer.StoreAsync();

            }
        }
    }


#else

    // to make Unity-Editor happy :-)
    void Start()
    {
        Debug.Log("UDP COM Start");

    }
    public void SendUDPMessage(byte[] data)
    {
        throw new System.NotSupportedException("API not supported in editor");
    }
    public void SendUDPMessage(string HostIP, string HostPort, byte[] data)
    {
        throw new System.NotSupportedException("API not supported in editor");
    }

#endif


    static MemoryStream ToMemoryStream(Stream input)
    {
        try
        {                                         // Read and write in
            byte[] block = new byte[0x1000];       // blocks of 4K.
            MemoryStream ms = new MemoryStream();
            while (true)
            {
                int bytesRead = input.Read(block, 0, block.Length);
                if (bytesRead == 0) return ms;
                ms.Write(block, 0, bytesRead);
            }
        }
        finally { }
    }

#if UNITY_WSA && !UNITY_EDITOR
    private void Socket_MessageReceived(Windows.Networking.Sockets.DatagramSocket sender,
        Windows.Networking.Sockets.DatagramSocketMessageReceivedEventArgs args)
    {
        //Debug.Log("GOT MESSAGE FROM: " + args.RemoteAddress.DisplayName);
        //Read the message that was received from the UDP  client.
        Stream streamIn = args.GetDataStream().AsStreamForRead();
        MemoryStream ms = ToMemoryStream(streamIn);
        byte[] msgData = ms.ToArray();


        //if (ExecuteOnMainThread.Count < 100)
        //{
        //    ExecuteOnMainThread.Enqueue(() =>
        //    {
        //        //Debug.Log("ENQEUED ");
                if (udpEvent != null)
                    udpEvent.Invoke(args.RemoteAddress.DisplayName, internalPort, msgData);
        //    });
        //}
    }


#endif
}