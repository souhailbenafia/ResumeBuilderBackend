using Domain.Entities.Identity;
using Infrastructure.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Net;
using System.Net.Mail;

namespace API.Controllers
{
    /// <summary>
    /// Authentication controller.
    /// </summary>
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMailer _mailer;
        private readonly SignInManager<User> _signInManager;
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;

        private IdentityOptions Options { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        public AuthenticationController(IConfiguration configuration, IMailer mailer, IOptions<IdentityOptions> options,
            
            SignInManager<User> signInManager,
            Microsoft.AspNetCore.Identity.UserManager<User> userManager)
        {
            _configuration = configuration;
            _mailer = mailer;
            _signInManager = signInManager;
            _userManager = userManager;

            Options = options.Value;


        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { error = "LoginIncorrectCredentials" });
            }

            var user = await _userManager.FindByEmailAsync(model.Username) ??
                       await _userManager.FindByNameAsync(model.Username) ??
                       await _userManager.FindByLoginAsync("provider", model.Username);

            if (user is null)
            {
                return BadRequest(new { error = "_resources.LoginIncorrectCredentials" });
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);

            if (result.Succeeded)
            {
                return Ok(new LoginResult());
            }

            if (result.IsLockedOut)
            {
                return Ok(new LoginResult(false, user.LockoutEnd, ""));
            }

            return BadRequest(new { error = "LoginIncorrectCredentials" });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(User model)
        {

            var result = await _userManager.CreateAsync(model);
                

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(new { error = "User Not Created" });
        }
        /// <summary>
        /// Terminates the user session.
        /// </summary>
        [HttpPost("logout")]
        public async Task Logout() => await _signInManager.SignOutAsync();

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.UserName) ??
                       await _userManager.FindByNameAsync(model.UserName) ??
                       await _userManager.FindByLoginAsync("provider", model.UserName);

            if (user is null)
            {
                return BadRequest(new { error = "UserNotFound" });
            }

            if (user.Email is null)
            {
                return BadRequest(new { error = "UserWithoutEmail" });
            }

            if (user.LockoutEnd > DateTime.Now)
            {
                return BadRequest(new { error = "UserLocked" });
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var message = new MailMessage
            {
                From = new MailAddress(_configuration.GetValue<string>("Mail:From")),
                Subject = string.Format(CultureInfo.CurrentCulture, "ResetPasswordEmailSubject")
            };

            await _mailer.SendAsync(new ResetPasswordEmail(user.Id, user.Id, user.Id,
                $"{Request.Scheme}://{Request.Host}/reset-password/{user.Id}/{WebUtility.UrlEncode(token)}"), "reset-password", message);

            return Ok();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user is null)
            {
                return BadRequest(new { error = "UserNotFound" });
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { Errors = errors });
            }

            return Ok();
        }

        [HttpPost("reset-password/token/verify")]
        public async Task<IActionResult> VerifyResetPasswordToken([FromBody] ResetPasswordBase model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);

            if (user is null)
            {
                return BadRequest();
            }

            if (!await _userManager.VerifyUserTokenAsync(user, Options.Tokens.PasswordResetTokenProvider,
                Microsoft.AspNetCore.Identity.UserManager<User>.ResetPasswordTokenPurpose, model.Token))
            {
                return BadRequest();
            }

            return NoContent();
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user is null)
            {
                return BadRequest(new { error = "Not found" });
            }
            if (!await _userManager.CheckPasswordAsync(user, model.OldPassword))
            {
                return BadRequest(new { error = "incorrect password" });
            }
            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { Errors = errors });
            }
            return Ok();
        }

        #region Helpers

        #endregion

        public class ChangePasswordModel
        {
            public string UserId { get; set; }

            public string NewPassword { get; set; }

            public string OldPassword { get; set; }

            public string PasswordConfirm { get; set; }
        }
        public class ForgotPasswordModel
        {
            public string UserName { get; set; }
        }
        public class LoginModel
        {
            /// <summary>
            /// Gets or sets user name or email.
            /// </summary>
            public string Username { get; set; }

            /// <summary>
            /// Gets or sets user password.
            /// </summary>
            public string Password { get; set; }
        }
        public class LoginResult
        {
            public bool Success { get; private set; }

            public DateTimeOffset? LockoutEnd { get; set; }

            public bool Locked => LockoutEnd.HasValue && DateTimeOffset.UtcNow < LockoutEnd.Value;

            public string Message { get; set; }

            public LoginResult(bool success = true) =>
                Success = success;

            public LoginResult(bool success, DateTimeOffset? lockoutEnd, string message) : this(success)
            {
                LockoutEnd = lockoutEnd;
                Message = message;
            }
        }
        public class ResetPasswordModel : ResetPasswordBase
        {
            /// <summary>
            /// Gets or sets password.
            /// </summary>
            public string Password { get; set; }

            /// <summary>
            /// Gets or sets password confirmation.
            /// </summary>
            public string PasswordConfirm { get; set; }
        }
        public class ResetPasswordBase
        {
            /// <summary>
            /// Gets or sets user id.
            /// </summary>
            public string Id { get; set; }

            /// <summary>
            /// Gets or sets reset password token.
            /// </summary>
            public string Token { get; set; }
        }
        public class ResetPasswordEmail
        {
            public string Id { get; private set; }

            public string FirstName { get; private set; }

            public string LastName { get; private set; }

            public string Url { get; private set; }

            public ResetPasswordEmail(string id, string firstName, string lastName, string url)
            {
                Id = id;
                FirstName = firstName;
                LastName = lastName;
                Url = url;
            }
        }

        public class UserModel
        {
        }
    }
}
