using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainerManagement.Domain;
namespace TrainerManagement.Infrastructure
{
    public class TrainerManagementContext : DbContext
    {
        public TrainerManagementContext(DbContextOptions<TrainerManagementContext> options): base(options)
        {

        }

        public virtual DbSet<Trainer> Trainers { get; set; }
    }
}
