using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionManagement.Api.DTOs
{
    public class TrainingSessionDTO
    {
        public long Id { get; set; }
        public long TrainerId { get; set; }
        public long CohortId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Location { get; set; }
        public bool IsVirtual { get; set; }
    }
}
