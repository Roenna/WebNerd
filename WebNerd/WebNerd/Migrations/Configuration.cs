namespace WebNerd.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebNerd.Models.EfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebNerd.Models.EfDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Users.AddOrUpdate(i => i.Id, new User { Name = "Roenna", Email = "mrocznakrolowa@mordor.me" });
            context.Users.AddOrUpdate(i => i.Id, new User { Name = "KrolMacius", Email = "wlatca@swiata.na" });
            context.Users.AddOrUpdate(i => i.Id, new User { Name = "Nuzumi", Email = "lubielamy@carl.yt" });
            context.Users.AddOrUpdate(i => i.Id, new User { Name = "Anrika", Email = "kaczamama@poczta.kk" });

            context.Games.AddOrUpdate(i => i.Id, new Game { Name = "Undertale", Year = 2015 });
            context.Games.AddOrUpdate(i => i.Id, new Game { Name = "Life is strange", Year = 2015 });
            context.Games.AddOrUpdate(i => i.Id, new Game { Name = "To the Moon", Year = 2011 });
        }
    
    }
}
