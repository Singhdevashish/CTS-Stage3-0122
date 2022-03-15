using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionManagement.Api.DTOs
{
    public class ReadTrainingSessionDTO : TrainingSessionDTO
    {
        public string TrainerName { get; set; }
        public string CohortCode { get; set; }
    }
}
