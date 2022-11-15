using System.ComponentModel.DataAnnotations;

namespace SMStoreNetFramework.WebUI.Models
{
    public class AdminLoginViewModel
    {
        [Required]
        public string Email { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}