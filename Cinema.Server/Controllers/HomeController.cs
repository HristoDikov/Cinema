﻿namespace Cinema.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class HomeController : ApiController
    {
        [Authorize]
        public ActionResult Get() 
        {
            return Ok("IT WORKS!!!");
        }
    }
}