namespace Kawanso.WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Kawanso.WebApi.Models.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Kawanso.WebApi.Models.DBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            SeedInitials(context);
        }

        private void SeedInitials(Kawanso.WebApi.Models.DBContext context)
        {
            if (!context.Users.Any(usr => usr.Email == "umerkhan@gmail.com"))
            {
                context.Users.Add(new Models.User { Email = "umerkhan@gmail.com", Password = "umerkhan", Created_At = DateTime.Now, Updated_At = DateTime.Now });
                context.SaveChanges();
            }

            if (!context.Tasks.Any(task => task.Name == "Assignment"))
            {
                context.Tasks.Add(new Models.Task { Name = "Assignment", Description = "First Assignment", Created_At = DateTime.Now });
                context.SaveChanges();
            }
        }

    }
}
