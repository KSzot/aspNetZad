﻿using RejestrOsobProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RejestrOsobProjekt.ViewModel
{
    public class HumanFormViewModel
    {
        public Human human { get; set; }
        public IEnumerable<Gender> genders { get; set; }
    }
}