using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace GetShip.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }

    public class Users
    {
        public static ApplicationUser Current_User(ApplicationDbContext db)
        {
            string curentUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var user = GetUser(db , curentUserId);
            return user;
        }
       public static ApplicationUser GetUser(ApplicationDbContext db , string id)
       {
            var user = new ApplicationUser();
            user = db.Users.Find(id);
            return user;
       }

    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [Display(Name = "Role")]
        public string Role { get; set; }
        [Required]
        [Display(Name="Age")]
        public int Age { get; set; }



        
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterCompanyView : RegisterViewModel
    {
        [Display(Name = "Company")]
        public Company Company { get; set; }

    }

    public class RegisterEmployeeView : RegisterViewModel
    {
        //public RegisterEmployeeView()
        //{
        //    Employe = new Employe();
        //}
        [Display(Name = "Employe")]
        public Employe Employe { get; set; }
    }
}
