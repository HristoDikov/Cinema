namespace Cinema.Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Data.Models;
    using Models.Identity;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;
    using Repositories.Contracts;
    using Microsoft.AspNetCore.Http;

    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly IIdentityRepository identityService;
        private readonly ApplicationSettings appSettings;

        public IdentityController(
            UserManager<User> userManager,
            IOptions<ApplicationSettings> appSettings, 
            IIdentityRepository identityService)
        {
            this.userManager = userManager;
            this.identityService = identityService;
            this.appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route(nameof(Register))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName,
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Created("/login", user.UserName);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route(nameof(Login))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValid)
            {
                return Unauthorized();
            }

            string token = identityService.GenerateJwtToker(
                user.Id, 
                user.UserName, 
                this.appSettings.Secret);

            return Accepted(new LoginResponseModel
            {
                Token = token,
            });
        }
    }
}
