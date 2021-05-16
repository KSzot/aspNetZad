using RejestrOsobProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrOsobProjekt.ViewModel
{
    public class UserFormViewModel
    {
        public User users { get; set; }
        public IEnumerable<Role> roles { get; set; }
    }
}