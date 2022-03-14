using SessionManagement.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionManagement.Core.Entitites
{
    public class TrainingSession : BaseEntity
    {
        public virtual long TrainerId { get; private set; }
        public virtual long CohortId { get; private set; }
        public virtual TrainingDates Dates { get; private set; }
        public virtual TrainingLocation Location { get; private set; }

        private TrainingSession() { }
        public TrainingSession(long trainerId, long cohortId, TrainingDates dates, TrainingLocation location)
        {
            //validation
            this.TrainerId = trainerId;
            this.CohortId = cohortId;
            this.Dates = dates;
            this.Location = location;
        }

        public void ChangeTrainer(Trainer trainer)
        {
            //validation
            this.TrainerId = trainer.Id;
        }

    }
}
