using System.Collections.Generic;

namespace Entities.DTOs
{
    public class UserDetailDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public List<int> OperationClaimsId { get; set; }
    }
}