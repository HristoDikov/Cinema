namespace Cinema.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class HomeController : ApiController
    {
        [Authorize]
        [HttpGet]
        public ActionResult Get() 
        {
            return Ok("IT WORKS!!!");
        }
    }
}
