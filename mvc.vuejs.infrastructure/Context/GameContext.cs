using System.Data.Entity;
using System.Configuration;

using mvc.vuejs.infrastructure.Entities;

namespace mvc.vuejs.infrastructure.Context
{
    public class GameContext : DbContext
    {
        public GameContext() : base(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Game> Games { get; set; }
    }
}
