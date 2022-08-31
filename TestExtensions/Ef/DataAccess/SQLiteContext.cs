using Microsoft.EntityFrameworkCore;
using TestExtensions.Ef.Models;
namespace TestExtensions.Ef.DataAccess
{
    public class SQLiteContext : DbContext
    {
        public const string NameDatabase = "Database.sqlite";
        public SQLiteContext()
        {
            CreateDatabase();
            CreateTablePeopleLoadItems();
        }

        public virtual DbSet<People> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=./{NameDatabase}");
        }

        internal void CreateDatabase()
        {
            if (File.Exists($"./{NameDatabase}") == false)
            {
                var create = File.Create($"./{NameDatabase}");
                create.Flush();
                create.Dispose();
            }
        }

        internal void CreateTablePeopleLoadItems()
        {
            Database.ExecuteSqlRaw("DROP TABLE People");
            Database.ExecuteSqlRaw("CREATE TABLE People(Id INTEGER PRIMARY KEY, Name varchar(100), Value REAL)");
            People p0 = new()
            {
                Name = "p1",
                Value = 100
            };
            People p1 = new()
            {
                Name = "p2",
                Value = 200
            };
            People p2 = new()
            {
                Name = "p3",
                Value = 300
            };
            People.AddRange(p0, p1, p2);
            SaveChanges();
        }
    }
}
