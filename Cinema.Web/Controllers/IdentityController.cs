//namespace Cinema.Web.Controllers
//{
//    using Data.Models;
//    using Services.Contracts;

//    using Models.Identity;
//    using System.Threading.Tasks;
//    using Microsoft.AspNetCore.Mvc;
//    using Microsoft.AspNetCore.Http;
//    using Microsoft.Extensions.Options;
//    using Microsoft.AspNetCore.Identity;

//    public class IdentityController : ApiController
//    {
//        private readonly UserManager<User> userManager;
//        private readonly IIdentityService identityService;
//        private readonly ApplicationSettings appSettings;

//        public IdentityController(
//            UserManager<User> userManager,
//            IOptions<ApplicationSettings> appSettings, 
//            IIdentityService identityService)
//        {
//            this.userManager = userManager;
//            this.identityService = identityService;
//            this.appSettings = appSettings.Value;
//        }

//        [HttpPost]
//        [Route(nameof(Register))]
//        [ProducesResponseType(StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        public async Task<ActionResult> Register(RegisterRequestModel model)
//        {
//            var result = await this.identityService.Register(model.UserName,model.Email, model.Password);

//            if (result.Succeeded)
//            {
//                return Ok();
//            }

//            return BadRequest(result.Errors);
//        }

//        [HttpPost]
//        [Route(nameof(Login))]
//        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
//        [ProducesResponseType(StatusCodes.Status202Accepted)]
//        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
//        {
//            var user = await this.userManager.FindByNameAsync(model.UserName);

//            if (user == null)
//            {
//                return Unauthorized();
//            }

//            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

//            if (!passwordValid)
//            {
//                return Unauthorized();
//            }

//            string token = identityService.GenerateJwtToker(
//                user.Id, 
//                user.UserName, 
//                this.appSettings.Secret);

//            return Accepted(new LoginResponseModel
//            {
//                Token = token,
//            });
//        }
//    }
//}
