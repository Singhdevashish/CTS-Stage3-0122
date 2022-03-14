using CohortManagement.Core.Events;
using CohortManagement.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CohortManagement.Core.Handlers
{
    public class TraineeAddedEventHandler : INotificationHandler<TraineeAddedEvent>
    {
        private readonly IEmailService emailService;

        public TraineeAddedEventHandler(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public async Task Handle(TraineeAddedEvent notification, CancellationToken cancellationToken)
        {
            var body = $"<h1>Dear {notification.TraineeName}</h1> " +
                $"<p>You have been registred for training on {notification.Technology}</p> <p>Your coach is {notification.CoachName}</p>";
           await  emailService.SendEmailAsync(notification.TraineeEmail, 
                                        "Registered for Cohort : "+notification.CohortCode, 
                                        body);
        }
    }
}
