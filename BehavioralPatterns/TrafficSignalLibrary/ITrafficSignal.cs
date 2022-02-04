namespace TrafficSignalLibrary
{
    public interface ITrafficSignal
    {
        string SignalId { get; set; }
        void TurnRed();
        void TurnGreen();
    }
}
