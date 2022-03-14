using System;
using System.Collections.Generic;
using System.Text;

namespace CohortManagement.Core.Events
{
    public class TraineeAddedEvent : BaseEvent
    {
        public string TraineeName { get; }
        public string TraineeEmail { get; }
        public string CohortCode { get; }
        public string CoachName { get; }
        public string Technology { get; }

        public TraineeAddedEvent(string traineeName, string traineeEmail, string cohortCode, string coachName, string technology)
        {
            this.TraineeName = traineeName;
            this.TraineeEmail = traineeEmail;
            this.CohortCode = cohortCode;
            this.CoachName = coachName;
            this.Technology = technology;
        }
    }
}
