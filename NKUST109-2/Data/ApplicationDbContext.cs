using KHLightTrail;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NKUST109_2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NKUST109_2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<VolumeData> VolumeData { get; set; }
        public DbSet<Message> ChatMessage { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}