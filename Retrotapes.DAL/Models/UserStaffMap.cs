using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrotapes.DAL.Models
{
    public class UserStaffMap
    {
        public int Id { get; set; } // or use composite key
        public string AspNetUserId { get; set; }
        public int StaffId { get; set; }
    }
}
