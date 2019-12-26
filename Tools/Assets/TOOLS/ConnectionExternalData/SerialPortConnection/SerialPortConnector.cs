/*

using UnityEngine;

using System.Threading;
using System.IO.Ports; //must use .net2.0 and not subset. see https://github.com/dwilches/SerialCommUnity 


public class SerialPortConnector : MonoBehaviour {

    internal bool IsDataStreaming;

    protected Thread _threadSerial;
    
    /// <summary>
    /// needs to be -1 compared to the time that the algo team sends
    /// time in miliseconds to sleep in between each data collection step. crucial to 
    /// keep balance between visualization thread and collection thread
    /// </summary>
    internal int SixdofTimeBetweenDataSending = 15;

    private bool _threadLooping = true;
    private SerialPort streamer;
    public int BaudRate = 115200;
    public int SerialPortNumber = 2;

    /// <summary>
    /// timeout for any sensor activity. if this time goes, sensor disconnects
    /// </summary>
    public int ReadingTimeout = 10000;

    

    public void OpenThread()
    {
        //close an existing thread
        if (_threadSerial == null)
        {
            //Debug.Log("Opening new Thread");
            
            // Create and start the thread
            _threadSerial = new Thread(new ThreadStart(StartThread));

            _threadSerial.Start();
            _threadLooping = true;
        }
    }
    private void StartThread()
    {
        //make the thread run always
        while (IsLooping())
        {
            try
            {
                //in case of device disconnection we need to try and reconnect
                ConnectToDevice();

                // Looping
                while (IsLooping())
                {
                    //performing this loop, only when data comes
                    LoopOnce();


                    IsDataStreaming = true;

                    ///adding sleep after each loop syncronizes the receiving side with the reality 
                    ///of data sending. this makes the received buffer to be at the size of 56 bytes 
                    ///that were sent.
                    ///it also offers some time for the visualization thread to do some work.
                    Thread.Sleep(SixdofTimeBetweenDataSending);
                }
            }
            catch (System.Exception ioe)
            {
                // A disconnection happened
                //if (SixdofTrackerAppManager.IsDebug) Debug.LogWarning("Device Disconnected. Exception: " + ioe.Message);

                IsDataStreaming = false;

                //in case of device disconnection we need to disconnect, in order to make a reconnect
                CloseDeviceConnection();

                //TODO: make sure the sleep doesnt affect the real Unity thread
                Thread.Sleep(1);
            }
        }
    }
    private void ConnectToDevice()
    {
        // Opens the connection on the serial port
        streamer = new SerialPort(ConvertSerialPortNumberToPortString(SerialPortNumber), BaudRate);
        streamer.ReadTimeout = ReadingTimeout;
        
        streamer.Open();
    }
    private void LoopOnce()
    {
        // reading process form device 
        
        //Initialize a buffer to hold the received data.
        //BufferSize could be more than you actually get.
        byte[] buffer = new byte[streamer.ReadBufferSize];

        //There is no accurate method for checking how many bytes are read 
        //unless you check the return from the Read() method 
        //once you perform any type of Reading from a SerialPort, the data is removed automatically.
        int bytesRead = streamer.Read(buffer, 0, buffer.Length);

        if (bytesRead < buffer.Length)
        {
            byte[] bufferOutput = new byte[bytesRead];
            ArrayExtensions.GetPartOfArray(buffer, ref bufferOutput, 0, bytesRead);

            DataSourceArray = ArrayExtensions.AppendValuesToArray(bufferOutput, DataSourceArray);
        }
        else
        {
            DataSourceArray = ArrayExtensions.AppendValuesToArray(buffer, DataSourceArray);
        }


        //SEND YOUR DATA TO A PARSER! DataSourceArray

    }
    private void StopThread()
    {
        lock (this)
        {
            _threadLooping = false;
        }
    }
    public bool IsLooping()
    {
        lock (this)
        {
            return _threadLooping;
        }
    }
    private void CloseDeviceConnection()
    {
        if (streamer != null)
        {
            streamer.Close();
            //streamer.Dispose();  --> never use a dispose.
            streamer = null;
        }
    }
    public void ThreadShutDown()
    {
        StopThread();
        CloseDeviceConnection();
        if (_threadSerial != null) _threadSerial = null;
    }


    internal bool IsDeviceConnected
    {
        get
        {
            return streamer != null && streamer.IsOpen;
        }
    }

    internal byte[] DataSourceArray;



    void Start()
    {
        if (comPortField != null)
            comPortField.text = SerialPortNumber.ToString();

        DataSourceArray = new byte[] { };
    }

    

    public UnityEngine.UI.InputField comPortField;
    public void ConnectToPort()
    {
        Debug.Log("ConnectToPort received");

        if (comPortField != null)
            SerialPortNumber = System.Convert.ToInt16(comPortField.text);

        OpenThread();
    }

    ///<summary>result should be COM2 or \\.\COM11</summary>
    private string ConvertSerialPortNumberToPortString(int port_num)
    {
        string serialComPortName = "";
        string serialComPortPrefix = "\\\\.\\"; // actually means \\.\

        if (port_num >= 10)
        {
            serialComPortName += serialComPortPrefix;
        }

        serialComPortName += "COM" + port_num.ToString();

        return serialComPortName;
    }
    
    private void OnDestroy()
    {
        ClosePortConnection();
    }

    public void ClosePortConnection()
    {
        Debug.Log("ClosePortConnection received");
        
        ThreadShutDown();
    }
}
*/