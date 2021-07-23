namespace Cinema.Web.Controllers
{
    using Application.Features.Ticket.Commands.BuyTicket;
    using Application.Features.Ticket.Commands.ReserveTicket;
    using Application.Features.Ticket.Commands.BuyTicketWithReservation;

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
        public async Task<ActionResult<TicketReservationSummary>> ReserveTicket(ReserveTicketCommand command)
        => await this.Mediator.Send(command);

        [HttpPost]
        [Route(nameof(BuyTicketWithReservation))]
        public async Task<ActionResult<BuyTicketWithReservationSummary>> BuyTicketWithReservation(BuyTicketWithReservationCommand command)
        => await this.Mediator.Send(command);
    }
}
