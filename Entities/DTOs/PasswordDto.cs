namespace Entities.DTOs
{
    // bu class için değil de ProductDto mesela. join methodu ile id'sini tuttuğumuz özelliklerin diğer özelliklerine de ulaşmamızı sağlıyor.
    // Bu özellikleri dal'da çekeriz. Bu classlar Dal'da yazacağımız methodun döndüreceği değer olacak.
    public class PasswordDto
    {
        public byte[] PasswordHash { get; set; } 
        public byte[] PasswordSalt { get; set; }
    }
}