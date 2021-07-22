//namespace Cinema.Web.Controllers
//{
//    using Models;
//    using Data.Models;
//    using Domain.Models;
//    using Domain.Contracts;

//    using System.Threading.Tasks;
//    using Microsoft.AspNetCore.Mvc;

//    public class MovieController : ApiController
//    {
//        private readonly INewMovie newMovie;

//        public MovieController(INewMovie newMovie)
//        {
//            this.newMovie = newMovie;
//        }

//        [HttpPost]
//        [Route(nameof(Create))]
//        public async Task<IActionResult> Create(MovieCreationModel model) 
//        {
//            NewMovieSummary summary = await this.newMovie.New(new Movie(model.Name, model.DurationMinutes));

//            if (summary.IsCreated)
//            {
//                return Ok(summary.Message);
//            }
//            else
//            {
//                return BadRequest(summary.Message);
//            }
//        }
//    }
//}
