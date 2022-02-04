using System;
using TrafficSignalLibrary;

namespace TrafficSignalLibraryClient
{
    class Program
    {
        static void Main(string[] args)
        {
            #region NoMediatorCode
            //TrafficSignal signal1 = new TrafficSignal() { SignalId = "S1" };
            //TrafficSignal signal2 = new TrafficSignal() { SignalId = "S2" };
            //TrafficSignal signal3 = new TrafficSignal() { SignalId = "S3" };
            //TrafficSignal signal4 = new TrafficSignal() { SignalId = "S4" };

            //signal1.TurnGreen();
            //signal2.TurnRed();
            //signal3.TurnRed();
            //signal4.TurnRed();

            //signal1.TurnRed();
            //signal2.TurnGreen();
            //signal3.TurnRed();
            //signal4.TurnRed();

            //signal1.TurnRed();
            //signal2.TurnRed();
            //signal3.TurnGreen();
            //signal4.TurnRed();

            //signal1.TurnRed();
            //signal2.TurnRed();
            //signal3.TurnRed();
            //signal4.TurnGreen();
            #endregion

            var signalMediator = new SignalMediator();
            TrafficSignal signal1 = new TrafficSignal(signalMediator) { SignalId = "S1" };
            TrafficSignal signal2 = new TrafficSignal(signalMediator) { SignalId = "S2" };
            TrafficSignal signal3 = new TrafficSignal(signalMediator) { SignalId = "S3" };
            TrafficSignal signal4 = new TrafficSignal(signalMediator) { SignalId = "S4" };

            signalMediator.Register(signal1);
            signalMediator.Register(signal2);
            signalMediator.Register(signal3);
            signalMediator.Register(signal4);

            signal1.TurnGreen();
            signal2.TurnGreen();
        }
    }
}
