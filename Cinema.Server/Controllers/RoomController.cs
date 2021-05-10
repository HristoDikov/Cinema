namespace Cinema.Server.Controllers
{
    using Models;
    using Domain.CinemaDomainContracts;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Cinema.Server.Domain.CinemaDomainContracts.Models;
    using Cinema.Server.Data.Models;

    public class RoomController : ApiController
    {
        private readonly INewRoom newRoom;

        public RoomController(INewRoom newRoom)
        {
            this.newRoom = newRoom;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<IActionResult> Create(RoomCreationModel model)
        {
            NewRoomSummary summary = await newRoom.New(new Room(model.CinemaId, model.Number, model.SeatsPerRow, model.Rows));

            if (summary.IsCreated)
            {
                return Ok(summary.Message);
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }
    }
}
