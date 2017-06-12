using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
//using System.Diagnostics;

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
        #region GetDeepUser
        public static ApplicationUser Deep_Current_User()
        {
            ApplicationUser user = null;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                string curentUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                user = GetDeepUser(db, curentUserId);
            }
            return user;
        }
       
        public static ApplicationUser GetDeepUser(ApplicationDbContext db , string id)
        {
                ApplicationUser user = db.Users.Find(id);
                return (ApplicationUser)user.DeepCopy();           
        }
        #endregion

        #region GetShallowUser
        public static ApplicationUser Shallow_Current_User()
        {
            ApplicationUser user = null;
            ApplicationDbContext db = new ApplicationDbContext();
            string curentUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            user = GetShallowUser(db, curentUserId);
            return user;
        }

        public static ApplicationUser GetShallowUser(ApplicationDbContext db, string id)
        {
            ApplicationUser user;
            try
            {
                user = db.Users.Find(id);
            }
            catch (System.NullReferenceException)
            {
                user = new ApplicationUser();
            }
            return (ApplicationUser)user;
        }
        #endregion
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

        [DataType(DataType.Text)]
        [Display(Name = "Secret Key")]
        public string SecretKey { get; set; }

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

        public System.Web.Mvc.SelectList Profesions { get; set; }

        public Profesion Profesion { get; set; }
    }
}
