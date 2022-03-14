using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CohortManagement.Core.Services;
using CohortManagement.Core.Events;

namespace CohortManagement.Core
{
    public class Cohort : BaseEntity, IAggregateRoot
    {
        private Cohort() { }

        public virtual string CohortCode { get; private set; }
        public virtual string TechnologyStack { get; private set; }
        public virtual string Coach { get; private set; }
        public virtual DateTime CreateOn { get; private set; }
       
        public Cohort(string cohortCode, string technologyStack, string coach)
        {
            //validation of details
            this.CohortCode = cohortCode;
            this.TechnologyStack = technologyStack;
            this.Coach = coach;
            this.CreateOn = DateTime.Now;
            Trainees = new List<Trainee>();
            TraineeCount = Trainees.Count();
            
        }

        
        public virtual List<Trainee> Trainees { get; private set; } 
        
        public long TraineeCount { get; private set; }

        public void AddTrainee(Trainee trainee)
        {
            if (trainee == null)
                throw new ArgumentException($"Cannot be null : {nameof(trainee)}");

            var Exits = Trainees.Exists(p => p.Id == trainee.Id);
            if (Exits)
                throw new InvalidOperationException("Trainee already present");

            Trainees.Add(trainee);
            
            var Event = new TraineeAddedEvent(trainee.Name, trainee.Email, this.CohortCode, this.Coach, this.TechnologyStack);
            DomainEvents.Add(Event);
        }
        public void RemoveTrainee(long traineeId)
        {
            //validations
            var trainee = SearchTrainee(traineeId);
            Trainees.Remove(trainee);
        }
        public void ChangeTraineeName(long traineeId, string newName)
        {
            //validations
            Trainee trainee = SearchTrainee(traineeId);
            trainee.ChangeName(newName);
        }

        private Trainee SearchTrainee(long traineeId)
        {
            var trainee = Trainees.Find(p => p.Id == traineeId);
            if (trainee == null)
                throw new TraineeNotFoundException(traineeId);
            return trainee;
        }
    }
}
