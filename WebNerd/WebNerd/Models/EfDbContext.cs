using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebNerd.Models
{
    public class EfDbContext : DbContext
    {
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Game> Games { get; set; }

    }
}