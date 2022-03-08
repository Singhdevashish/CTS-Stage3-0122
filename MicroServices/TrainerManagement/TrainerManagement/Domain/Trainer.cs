using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainerManagement.Domain
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PrimarySkill { get; set; }
        public string SecondarySkills { get; set; }
    }
}
