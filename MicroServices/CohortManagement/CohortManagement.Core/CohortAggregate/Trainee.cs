using System;
using System.Collections.Generic;
using System.Text;

namespace CohortManagement.Core
{
    public class Trainee : BaseEntity
    {
        private Trainee() { }     //ORMs

        public virtual string Name { get; private set; }
        public virtual string Email { get; private set; }
        public virtual DateTime DateOfJoining { get; private set; }

        public long CohortId { get; set; }
      

        public Trainee(string name, string email, DateTime dateOfJoining)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"Invalid value for : ${nameof(name)}");

            if (string.IsNullOrEmpty(email) || !email.EndsWith("@cognizant.com"))
                throw new ArgumentException($"Invalid value for : ${nameof(email)}");

            if (dateOfJoining.Date < DateTime.Now.Date)
                throw new ArgumentException($"Invalid value for : ${nameof(dateOfJoining)}");

            this.Name = name;
            this.Email = email;
            this.DateOfJoining = DateOfJoining;
        }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrEmpty(newName))
                throw new ArgumentException($"Invalid value for : ${nameof(newName)}");

            if (Name == newName)
                return;
            Name = newName;
        }
    }
}
