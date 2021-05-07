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
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Gender> Genders { get; set; }
    }
}