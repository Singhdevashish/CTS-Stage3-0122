using System;

namespace TrafficSignalLibrary
{
    public class TrafficSignal : ITrafficSignal
    {
        public string SignalId { get; set; }
        private string CurrentLight;
        private readonly IMediator mediator;
        public TrafficSignal(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public void TurnGreen()
        {
            CurrentLight = "Green";
            Console.WriteLine("{0} turned {1}", SignalId, CurrentLight);
            mediator.Notify(this);
        }

        public void TurnRed()
        {
            CurrentLight = "Red";
            Console.WriteLine("{0} turned {1}", SignalId, CurrentLight);
        }
    }
}
