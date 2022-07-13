using Microsoft.EntityFrameworkCore;

namespace WebReminderApp.Database
{
    public class DataContext : DbContext
    {
        public DbSet<Reminders> Reminders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=JAPPS\SQLEXPRESS; Database=Reminders; Integrated Security=True;");
        }
    }
}
