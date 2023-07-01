using Microsoft.EntityFrameworkCore;

namespace ViraCare.Models
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = LoadData.db");

        }
        private static DataContext _ins;
        public static DataContext ins
        {
            get
            {
                if (_ins == null)
                    _ins = new DataContext();
                return _ins;
            }
            set { _ins = value; }
        }
        public DbSet<Input> Inputs { get; set; }


    }
}
