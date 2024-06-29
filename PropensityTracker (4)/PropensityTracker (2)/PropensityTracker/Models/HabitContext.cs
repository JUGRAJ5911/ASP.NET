using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PropensityTracker.Models
{
    public class HabitContext : DbContext
    {
        public DbSet<Habit> Habits { get; set; }


    }
}