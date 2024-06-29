using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PropensityTracker.Models
{
    public class UserContext : DbContext
    {
        public DbSet<UserMaster> UserMasters { get; set; }


    }
}