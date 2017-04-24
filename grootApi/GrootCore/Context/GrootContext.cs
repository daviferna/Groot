using GrootCore.Models;
using System.Data.Entity;

namespace grootApi.Context
{
    public class GrootContext:DbContext
    {
        public GrootContext() : base("name=GrootConnectionString")
        {

        }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Groot> Groots {get;set;}
        public DbSet<Action> Actions { get; set; }
        public DbSet<Snapshot> Snapshots { get; set; }
    }
}