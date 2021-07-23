namespace Cinema.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Cinema.Application.Features.Ticket.Commands.BuyTicket;

    using System.Threading.Tasks;

    public class TicketController : ApiController
    {

        [HttpPost]
        [Route(nameof(BuyTicket))]
        public async Task<ActionResult<BuyTicketSummary>> BuyTicket(BuyTicketCommand command)
        => await this.Mediator.Send(command);


        //[HttpPost]
        //[Route(nameof(ReserveTicket))]
        //public async Task<IActionResult> ReserveTicket(TicketCreationModel ticketModel)
        //{
        //    TicketReservationSummary summary = await this.newTicketReservation.Reserve(new Ticket(ticketModel.ProjectionId, ticketModel.Row, ticketModel.Col));

        //    if (summary.IsCreated)
        //    {
        //        return Ok(summary);
        //    }
        //    else
        //    {
        //        return BadRequest(summary.Message);
        //    }
        //}

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
