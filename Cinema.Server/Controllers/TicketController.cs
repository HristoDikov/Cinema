namespace Cinema.Server.Controllers
{
    using Models;
    using Data.Models;
    using Domain.CinemaDomainContracts;
    using Domain.CinemaDomainContracts.Models;

    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class TicketController : ApiController
    {
        private readonly INewTicket newTicket;
        private readonly ITicketReservation newTicketReservation;
        private readonly IBuyTicketWithReservation buyTicketWithReservation;

        public TicketController(INewTicket newTicket, ITicketReservation newTicketReservation, IBuyTicketWithReservation buyTicketWithReservation)
        {
            this.newTicket = newTicket;
            this.newTicketReservation = newTicketReservation;
            this.buyTicketWithReservation = buyTicketWithReservation;
        }

        [HttpPost]
        [Route(nameof(BuyTicket))]
        public async Task<IActionResult> BuyTicket(TicketCreationModel ticketModel) 
        {
            NewTicketSummary summary = await this.newTicket.New(new Ticket(ticketModel.ProjectionId, ticketModel.Row, ticketModel.Col));

            if (summary.IsCreated)
            {
                return Ok(summary);
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }


        [HttpPost]
        [Route(nameof(ReserveTicket))]
        public async Task<IActionResult> ReserveTicket(TicketCreationModel ticketModel)
        {
            TicketReservationSummary summary = await this.newTicketReservation.Reserve(new Ticket(ticketModel.ProjectionId, ticketModel.Row, ticketModel.Col));

            if (summary.IsCreated)
            {
                return Ok(summary);
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }

        [HttpPost]
        [Route(nameof(BuyTicketWithReservation))]
        public async Task<IActionResult> BuyTicketWithReservation(string uniqueKey)
        {
            BuyTicketWithReservationSummary summary = await this.buyTicketWithReservation.BuyWithReservation(uniqueKey);

            if (summary.IsCreated)
            {
                return Ok(summary);
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }
    }
}
