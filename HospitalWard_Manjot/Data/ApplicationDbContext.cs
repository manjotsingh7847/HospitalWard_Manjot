using System;
using System.Collections.Generic;
using System.Text;
using HospitalWard_Manjot.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalWard_Manjot.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Patient> Patiens { get; set; }
        public DbSet<Ward> Wards { get; set; }
    }
}
