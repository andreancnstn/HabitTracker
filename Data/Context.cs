using Abc.HabitTracker.Api.BadgeAggregate;
using Abc.HabitTracker.Api.HabitAggregate;
using Microsoft.EntityFrameworkCore;

namespace Abc.HabitTracker.Api.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt)
        {
            
        }

        public DbSet<Habit> Habits { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<DaysOff> daysOffs { get; set; }
        public DbSet<BadgeUse> BadgeUses { get; set; }
    }
}