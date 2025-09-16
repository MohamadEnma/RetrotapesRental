using Retrotapes.DAL.Models;

namespace Retrotapes.WEB.ViewModels
{
    public class StaffUserViewModel
    {
        public Staff Staff { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
