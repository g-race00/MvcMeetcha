using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace MvcMeetcha.Data
{
    // Add profile data for application users by adding properties to the User class
    public class Account: IdentityUser
    {
        public Admin? Admin { get; set; }
        public Member? Member { get; set; }
    }
}
