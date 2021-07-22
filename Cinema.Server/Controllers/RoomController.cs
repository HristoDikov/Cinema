//namespace Cinema.Web.Controllers
//{
//    using Models;
//    using Data.Models;
//    using Domain.Models;
//    using Domain.Contracts;

//    using Microsoft.AspNetCore.Mvc;
//    using System.Threading.Tasks;

//    public class RoomController : ApiController
//    {
//        private readonly INewRoom newRoom;

//        public RoomController(INewRoom newRoom)
//        {
//            this.newRoom = newRoom;
//        }

//        [HttpPost]
//        [Route(nameof(Create))]
//        public async Task<IActionResult> Create(RoomCreationModel model)
//        {
//            NewRoomSummary summary = await newRoom.New(new Room(model.CinemaId, model.Number, model.SeatsPerRow, model.Rows));

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
