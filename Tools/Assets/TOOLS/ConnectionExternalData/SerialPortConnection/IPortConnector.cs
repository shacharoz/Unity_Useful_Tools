
public interface IPortConnector {
    bool IsDataStreaming();
    void ConnectToPort();
    void ClosePortConnection();

}
