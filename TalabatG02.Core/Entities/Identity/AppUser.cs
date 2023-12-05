﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalabatG02.Core.Entities.Identity
{
    public class AppUser:IdentityUser
    {
        public string DisplayName { get; set; }

        public Address Adress { get;set; }
    }
}
