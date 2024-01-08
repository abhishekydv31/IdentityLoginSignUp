using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityLoginSignUp.Areas.Identity.Data;

// Add profile data for application users by adding properties to the IdentityLoginSignUpUser class
public class IdentityLoginSignUpUser : IdentityUser
{
    public string Name { get; set; }
    public string MobileNo{ get; set; }
}

