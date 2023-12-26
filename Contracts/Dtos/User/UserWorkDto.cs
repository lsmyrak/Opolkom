using Contracts.Dtos.Task;

namespace Contracts.Dtos.User
{
    public class UserWorkDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public RoleDto UserRole { get; set; }
        public virtual WorkListDto WorkListDto { get; set; }
    }
}
