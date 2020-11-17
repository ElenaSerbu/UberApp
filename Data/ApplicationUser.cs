using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public int WatchlistID { get; set; }
    }
}
