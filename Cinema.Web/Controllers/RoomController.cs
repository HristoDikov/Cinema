namespace Cinema.Web.Controllers
{
    using Application.Features.Room.Commands.CreateRoom;

    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class RoomController : ApiController
    {
        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<CreateRoomSummary>> Create(CreateRoomCommand model)
        => await this.Mediator.Send(model);
    }
}
