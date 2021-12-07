using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using webdev_semester_1.Models;

namespace webdev_semester_1.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        public readonly AlexAndersenDBContext _db;


        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            AlexAndersenDBContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(100)]
            [Display(Name = "Fornavn")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(100)]
            [Display(Name = "Efternavn")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            /////////////////
            // Driver License

            // Driver License number
            [Required]
            [Display(Name = "Kørekort nummer")]
            public int DriverLicenseNo { get; set; }

            // DriverLicenseExperationDate
            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Kørekort udløbsdato")]
            public DateTime DriverLicenseExperationDate { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Udløbsdato")] // TruckLicense / Førekort udløbsdato
            public DateTime TruckLicenseExperationDate { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Udløbsdato")] // EU Kvalifikations udløbsdato
            public DateTime EUQualificationExperationDate { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new User { 
                    UserName = Input.Email,
                    Email = Input.Email, FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    DepartmentId = 1,
                    RoleId = 1
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {

                    // Add driver license
                    var license = new DriverLicense
                    {
                        DriverId = user.Id,
                        TypeId = 1
                    };

                    _db.DriverLicenses.Add(license);
                    _db.SaveChanges();


                    // Add driver info
                    var driverInfo = new DriverInfo
                    {
                        DriverLicenseNo = Input.DriverLicenseNo,
                        DriverLicenseExperationDate = Input.DriverLicenseExperationDate,
                        DriverLicenseImage = "driver-license.jpg",
                        TruckLicenseExperationDate = Input.TruckLicenseExperationDate,
                        TruckLicenseImage = "truck-license.jpg",
                        EuqualificationExperationDate = Input.EUQualificationExperationDate,
                        EuqualificationImage = "eu-qualification.jpg",
                        TypeId = 1,
                        UserId = user.Id
                    };

                    _db.DriverInfos.Add(driverInfo);
                    _db.SaveChanges();







                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
