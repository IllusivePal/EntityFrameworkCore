using Microsoft.EntityFrameworkCore;
using SamuraiAppCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiAppCore.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Qoute> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                 "Server = ZYLUN-PC-0396\\SQL2014;Database = SamuraiDataCore;user id=sa;password=systemadmin "
                );
        }
    }
}
