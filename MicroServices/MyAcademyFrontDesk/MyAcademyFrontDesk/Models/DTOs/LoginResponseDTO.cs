using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAcademyFrontDesk.Models
{
    public class LoginResponseDTO
    {
        public string jwt { get; set; }
        public string name { get; set; }
        public string role { get; set; }
    }
}
