using bd.vienkiemsoat.web.data.Entities;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace bd.vienkiemsoat.web.data
{
    public class ApplicationIdentityContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public DbSet<CoSoEntity> Cosos { get; set; }


        public ApplicationIdentityContext() : base("Server=112.78.2.30,1433;Database=vks22088_vienkiemsat.bd; user=vks22088_vienkiemsat;Password=Vks@123!;MultipleActiveResultSets=true")
        {
        }

        public ApplicationIdentityContext(string connectionString) : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<CoSoEntity>().ToTable("Coso");            

            base.OnModelCreating(builder);
        }

    }
}
