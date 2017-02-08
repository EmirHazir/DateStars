using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarsDate.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Profile")]
        public int ProfileId { get; set; }

        public Profile Profile { get; set; }
    }
}
