namespace DesSistemas.SnackNow.Api.Dto.UserSystemPassRecovery
{
    public class ConfirmSmsRequest
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}