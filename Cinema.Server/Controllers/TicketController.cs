namespace Cinema.Web.Controllers
{
    using Application.Features.Ticket.Commands.BuyTicket;
    using Application.Features.Ticket.Commands.ReserveTicket;

    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class TicketController : ApiController
    {

        [HttpPost]
        [Route(nameof(BuyTicket))]
        public async Task<ActionResult<BuyTicketSummary>> BuyTicket(BuyTicketCommand command)
        => await this.Mediator.Send(command);


        [HttpPost]
        [Route(nameof(ReserveTicket))]
        public async Task<ActionResult<ReservedTicketOutputModel>> ReserveTicket(ReserveTicketCommand command)
        => await this.Mediator.Send(command);

        //[HttpPost]
        //[Route(nameof(BuyTicketWithReservation))]
        //public async Task<IActionResult> BuyTicketWithReservation(string uniqueKey)
        //{
        //    BuyTicketWithReservationSummary summary = await this.buyTicketWithReservation.BuyWithReservation(uniqueKey);

        //    if (summary.IsCreated)
        //    {
        //        return Ok(summary);
        //    }
        //    else
        //    {
        //        return BadRequest(summary.Message);
        //    }
        //}
    }
}
