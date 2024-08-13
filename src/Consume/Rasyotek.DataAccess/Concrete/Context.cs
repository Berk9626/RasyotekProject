using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rasyotek.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.DataAccess.Concrete
{
    public class PersonelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=DESKTOP-IMFRFJD\\SQLSERVER2022EXP; database=RasyotekDb; integrated security=true; TrustServerCertificate=True");
        }
        public DbSet<Personel> Personels { get; set; }
    }
}
