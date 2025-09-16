namespace Retrotapes.WEB.ViewModels
{
    public class StaffViewModel
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string Username { get; set; }
        public bool Active { get; set; }
        public string? Role { get; set; } // Example: from related User
    }
}
