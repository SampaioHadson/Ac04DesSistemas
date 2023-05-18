namespace DesSistemas.SnackNow.Api.Dto.UserSystemPassRecovery
{
    public class ChangePasswordRequest
    {
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string CodeVerify { get; set; }
        public string RandomCode { get; set; }
    }
}