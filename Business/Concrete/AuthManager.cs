using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Concrete
{
    //İş yapan class. Dal'ı injekte edip database ile iletişime geçiliyor. Dal'dan farklı olarak iş kodları yazılıyor.
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        
        //Parametre olarak verdiğimiz şifre ile önce hash ve salt oluşuturuyor. Daha sonra diğer parametre olarak verdiğimiz user bilgileri 
        //ile birleştirip user oluştırıyor. Daha sonra bunu usermanager'a gönderiyor.
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password,out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Kayıt yapıldı");
        }

        //email ile database'den kullanıcıyı çekiyoruz. Eğer gelen veri yoksa kullanıcı bulunamadı hatası döndürüyoruz
        //gönderilen şifreyi database de ki hash ve salt ile kontrole ediyoruz.
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.PasswordHash,userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        //kullanıcının girdiği email ile databse de kayıt var mı kontrol ediyoruz. Varsa hata döndürüyoruz. 
        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email)!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult();
        }

        //Verdiğimiz user bilgisi ile database'den rollerini çekiyoruz. Daha sonra user bilgisi ve roller ile token oluşturuyoruz.
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
        
    }
}