using System.Data.Entity;
using UsersRegistrationWebAPI.Entidades;

namespace UsersRegistrationWebAPI.dao
{
    public class EntidadesContext : DbContext
    {
        public DbSet<User>  Users { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<ListApplicationModuleUser> ListApplicationModuleUsers { get; set; }
        public DbSet<ApplicationModule> ApplicationModules { get; set; }
        public DbSet<Functionality> features { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<ProfilePicture>().HasRequired(m => m.User);
            builder.Entity<PersonalInformation>().HasRequired(m => m.User);
            builder.Entity<PersonalInformation>().HasRequired(m => m.User);
            builder.Entity<ListApplicationModuleUser>().HasRequired(m => m.User);

            builder.Entity<ListApplicationModuleUser>().HasRequired(m => m.ApplicationModule);
            builder.Entity<Functionality>().HasRequired(m => m.ApplicationModule);

            builder.Entity<Service>().HasRequired(m => m.Functionality);
        }

        

    }
}

