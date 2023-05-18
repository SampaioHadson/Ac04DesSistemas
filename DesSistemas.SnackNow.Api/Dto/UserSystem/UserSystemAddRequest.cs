namespace DesSistemas.SnackNow.Api.Dto.UserSystem
{
    public class UserSystemAddRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string GivenName { get; set; } = null!;
        public string FamilyName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Nickname { get; set; } = null!;
        public string Cellphone { get; set;} = null!;
    }
}