namespace Portal.Models
{
    public class AuthenticatedUserModel
    {
        public string Access_Token { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
