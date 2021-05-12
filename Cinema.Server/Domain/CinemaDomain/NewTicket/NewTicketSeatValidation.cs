namespace Cinema.Server.Domain.CinemaDomain.NewTicket
{
    using Services.Contracts;
    using Data.ModelsContracts;
    using CinemaDomainContracts;
    using CinemaDomainContracts.Models;

    using System.Threading.Tasks;
    using Cinema.Server.Data.Dtos;

    public class NewTicketSeatValidation : INewTicket
    {
        private readonly ISeatRepository seatRepository;
        private readonly INewTicket newTicket;

        public NewTicketSeatValidation(ISeatRepository seatRepository, INewTicket newTicket)
        {
            this.seatRepository = seatRepository;
            this.newTicket = newTicket;
        }

        public async Task<NewTicketSummary> New(ITIcketCreation ticket)
        {
            SeatDto seat = await this.seatRepository.GetSeatByProjIdRowAndCol(ticket.ProjectionId, ticket.RowNumber, ticket.ColNumber);

            if (seat == null)
            {
                return new NewTicketSummary(false, $"There is no seat with row number '{ticket.RowNumber}' & col number: '{ticket.ColNumber}'!");
            }

            return await this.newTicket.New(ticket);
        }
    }
}
