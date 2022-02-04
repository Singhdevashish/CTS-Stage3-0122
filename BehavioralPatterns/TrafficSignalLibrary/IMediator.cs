using System;
using System.Text;

namespace TrafficSignalLibrary
{
    public interface IMediator
    {
        void Register(ITrafficSignal signal);
        void Notify(ITrafficSignal signal);
    }
}
