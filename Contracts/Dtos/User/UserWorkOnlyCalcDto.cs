namespace Contracts.Dtos.User
{
    public class UserWorkOnlyCalcDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public RoleDto UserRole { get; set; }
        public int TaskCount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
