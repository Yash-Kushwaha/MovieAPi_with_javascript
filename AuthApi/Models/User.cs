using System.ComponentModel.DataAnnotations;

namespace AuthApi.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }

    }
}
