using SessionManagement.Core.Entitites;
using SessionManagement.Core.Interfaces;
using SessionManagement.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionManagement.Core.Services
{
    public class SessionService : ISessionService
    {
        private readonly IRepository<Trainer> trainersRepository;
        private readonly IRepository<Cohort> cohortsRepository;
        private readonly IRepository<TrainingSession> trainingSessionRepository;

        public SessionService(IRepository<Trainer> trainersRepository, 
                              IRepository<Cohort> cohortsRepository, 
                              IRepository<TrainingSession> trainingSessionRepository = null)
        {
            this.trainersRepository = trainersRepository;
            this.cohortsRepository = cohortsRepository;
            this.trainingSessionRepository = trainingSessionRepository;
        }

        public async Task<TrainingSession> Add(TrainingSession session)
        {
            var spec = new GetSessionsForTrainerInGivenDurationSpecification(session.TrainerId, session.Dates.FromDate.Date, session.Dates.ToDate.Date);
            var ExistingTrainings = trainingSessionRepository.Get(spec);

            if (ExistingTrainings.Any())
                throw new ArgumentException("Trainer already assigned to another session");

            session = trainingSessionRepository.Add(session);
            await trainingSessionRepository.SaveAsync();
            return session;
        }

        public async Task<int> AddCohort(Cohort cohort)
        {
            cohortsRepository.Add(cohort);
            return await cohortsRepository.SaveAsync();
        }

        public async Task<int> AddTrainer(Trainer trainer)
        {
            trainersRepository.Add(trainer);
            return await trainersRepository.SaveAsync();
        }

        public string GetCohortCode(TrainingSession session)
        {
            var GetByIdSpec = new GetCohortCodeFromIdSpecification(session.CohortId);
            var Cohort = cohortsRepository.Get(GetByIdSpec).FirstOrDefault();
            return Cohort.CohortCode;
        }

        public IReadOnlyCollection<TrainingSession> GetSessions()
        {
            var Spec = BaseSpecification<TrainingSession>.All;
            var Sessions = trainingSessionRepository.Get(Spec);
            return Sessions;
        }

        public string GetTrainerName(TrainingSession session)
        {
            var Spec = new GetTrainerByIdSpecification(session.TrainerId);
            var Trainer = trainersRepository.Get(Spec).FirstOrDefault();
            return Trainer.Name;
        }
    }
}
