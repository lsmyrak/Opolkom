namespace WebAPI
{
    public class AuthenticationSetting
    {
        public string JwtKey { get; set; }
        public string JwtExperieDays { get; set; }
        public string JwtIssuer { get; set; }
    }
}
