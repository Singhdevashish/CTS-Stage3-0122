using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CohortManagement.Core.Events
{
    public abstract class BaseEvent : INotification
    {
        public DateTimeOffset CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
