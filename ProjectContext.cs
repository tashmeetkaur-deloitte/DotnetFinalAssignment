using System;  
using System.Collections.Generic;   
using System.Linq;
using DotnetAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetAssignment;
public class ProjectContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Issue> Issues { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Label> Labels { get; set; }
        public ProjectContext(DbContextOptions options):base(options)
        {
            
        }

    }