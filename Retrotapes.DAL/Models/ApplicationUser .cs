using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrotapes.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int? StaffId { get; set; }
    }
}
