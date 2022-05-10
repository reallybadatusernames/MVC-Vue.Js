namespace mvc.vuejs.infrastructure.Migrations
{

    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    using mvc.vuejs.infrastructure.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<mvc.vuejs.infrastructure.Context.GameContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(mvc.vuejs.infrastructure.Context.GameContext context)
        {
            if (!context.Games.Any())
            {
                context.Games.AddRange(
                    new List<Game>
                    {
                        new Game{ Name = "Game 1", Description = "Description of Game 1" },
                        new Game{ Name = "Game 2", Description = "Description of Game 2" },
                        new Game{ Name = "Game 3", Description = "Description of Game 3" },
                        new Game{ Name = "Game 4", Description = "Description of Game 4" },
                        new Game{ Name = "Game 5", Description = "Description of Game 5" },
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
