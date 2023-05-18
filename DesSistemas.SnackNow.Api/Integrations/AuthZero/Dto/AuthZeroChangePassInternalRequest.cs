namespace DesSistemas.SnackNow.Api.Integrations.AuthZero.Dto
{
    public class AuthZeroChangePassInternalRequest
    {
        public string AuthZeroId { get; set; }
        public string NewPassword { get; set;}

        public AuthZeroChangePassInternalRequest(string authZeroId, string newPassword)
        {
            AuthZeroId = authZeroId;
            NewPassword = newPassword;
        }
    }
}