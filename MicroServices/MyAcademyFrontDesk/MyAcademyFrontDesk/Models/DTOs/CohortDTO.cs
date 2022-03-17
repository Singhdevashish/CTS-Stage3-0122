using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyAcademyFrontDesk.Models
{
    public class CohortDTO
    {
        public long Id { get; set; }
        [Required]
        public string CohortCode { get; set; }
        [Required]
        public string TechnologyStack { get; set; }
        [Required]
        public string Coach { get; set; }
        public DateTime CreateOn { get; set; }
        public List<TraineeDTO> Trainees { get; set; }
        public long TraineeCount { get; set; }
    }
}
