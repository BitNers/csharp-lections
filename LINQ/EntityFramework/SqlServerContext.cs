using LINQ.EntityFramework.Escola;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.EntityFramework
{
    internal class SqlServerContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<MateriaModel> Materias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Data Source=shepard.local;Initial Catalog=csharp-lession;Persist Security Info=True;User ID=sa;Password=Laboratorio@123;MultipleActiveResultSets=True;TrustServerCertificate=True");
        }
    }
}
