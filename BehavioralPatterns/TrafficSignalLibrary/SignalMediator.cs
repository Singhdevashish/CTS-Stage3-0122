using System.Collections.Generic;

namespace TrafficSignalLibrary
{
    public class SignalMediator : IMediator
    {
        private readonly Dictionary<string, ITrafficSignal> signals;
        public SignalMediator()
        {
            signals = new Dictionary<string, ITrafficSignal>();
        }
        public void Notify(ITrafficSignal signal)
        {
            foreach (var signalId in signals.Keys)
                if (signal.SignalId != signals[signalId].SignalId)
                    signals[signalId].TurnRed();
        }

        public void Register(ITrafficSignal signal)
        {
            signals.Add(signal.SignalId, signal);
        }
    }
}
