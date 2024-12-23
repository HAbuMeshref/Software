
namespace Domain.Common
{
    public class SharedSettings
    {
        public static string Secret { get; set; }
        public static string token { get; set; }
        public static int JwtExpireDays { get; set; }
        public static string ConnectionString { get; set; }


    }
}
