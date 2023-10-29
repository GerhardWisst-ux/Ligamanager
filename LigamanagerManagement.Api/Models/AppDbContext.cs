﻿using LigaManagerManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigaManagerManagement.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Spieltag> Spieltage { get; set; }
        public DbSet<Verein> Vereine { get; set; }
        public DbSet<Tabelle> Tabellen { get; set; }
        public DbSet<Saison> Saisonen { get; set; }
        public DbSet<Liga> Ligen { get; set; }
       
    }
}
