using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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
            this.CohortCode = CohortCode;
            this.TechnologyStack = technologyStack;
            this.Coach = coach;
            this.CreateOn = DateTime.Now;
        }

        private List<Trainee> _trainees { get; set; } = new List<Trainee>();
        public virtual IEnumerable<Trainee> Trainees
        {
            get { return _trainees.AsReadOnly(); }
        }
        public long TraineeCount { get { return _trainees.Count; } }

        public void AddTrainee(Trainee trainee)
        {
            if (trainee == null)
                throw new ArgumentException($"Cannot be null : {nameof(trainee)}");

            var Exits = _trainees.Exists(p => p.Id == trainee.Id);
            if (Exits)
                throw new InvalidOperationException("Trainee already present");

            _trainees.Add(trainee);
        }
        public void RemoveTrainee(long traineeId)
        {
            //validations
            var trainee = SearchTrainee(traineeId);
            _trainees.Remove(trainee);
        }
        public void ChangeTraineeName(long traineeId, string newName)
        {
            //validations
            Trainee trainee = SearchTrainee(traineeId);
            trainee.ChangeName(newName);
        }

        private Trainee SearchTrainee(long traineeId)
        {
            var trainee = _trainees.Find(p => p.Id == traineeId);
            if (trainee == null)
                throw new TraineeNotFoundException(traineeId);
            return trainee;
        }
    }
}
