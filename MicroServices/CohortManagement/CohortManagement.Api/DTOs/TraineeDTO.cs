using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CohortManagement.Api.DTOs
{
    public class TraineeDTO
    {
        public long Id { get; set; }
        [Required, StringLength(30)]
        public string Name { get;  set; }
        [Required, StringLength(50)]
        public string Email { get;  set; }
        public DateTime DateOfJoining { get;  set; }

        public long CohortId { get; set; }
    }
}
