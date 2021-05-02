using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RejestrOsobProjekt.Models
{
    public class StoreContext : DbContext
    {
        public DbSet<Human> Humans { get; set; }
    }
}