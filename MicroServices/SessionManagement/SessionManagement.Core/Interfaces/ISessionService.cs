using SessionManagement.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SessionManagement.Core.Interfaces
{
    public interface ISessionService
    {
        Task<TrainingSession> Add(TrainingSession session);
        IReadOnlyCollection<TrainingSession> GetSessions();
        string GetTrainerName(TrainingSession session);
        string GetCohortCode(TrainingSession session);
        Task<int> AddTrainer(Trainer trainer);
        Task<int> AddCohort(Cohort cohort);
    }
}
