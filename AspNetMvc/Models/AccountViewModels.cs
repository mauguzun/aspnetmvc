using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace AspNetMvc.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }
    public class AppDbInit :DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
     
        protected override void Seed(ApplicationDbContext context)
        {
            var userManage = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManage = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var admin = new IdentityRole() { Name = "admin" };
            var user = new IdentityRole() { Name = "user" };

            roleManage.Create(admin);
            roleManage.Create(user);

            var adminAcc = new ApplicationUser() { Email = "mauguzun+admin@gmail.com" ,UserName = "admin" };

           
            if (userManage.Create(adminAcc, "De171717!").Succeeded)
            {
                userManage.AddToRole(adminAcc.Id, admin.Name);
                userManage.AddToRole(adminAcc.Id, "user");
            }

            var userAcc = new ApplicationUser() { Email = "mauguzun+user@gmail.com", UserName = "user" };
            if (userManage.Create(userAcc, "trance12").Succeeded)
            {
                userManage.AddToRole(adminAcc.Id, "user");
            }

            base.Seed(context);
        }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

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
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

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

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
