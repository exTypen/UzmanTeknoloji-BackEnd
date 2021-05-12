namespace Entities.DTOs
{
    public class PasswordDto
    {
        public byte[] PasswordHash { get; set; } 
        public byte[] PasswordSalt { get; set; }
    }
}