namespace Cinema.Application.Features.Ticket.Commands.BuyTicket
{
    using Domain.EntitiesContracts;
    using System.Threading.Tasks;

    public interface IBuyTicket
    {
        Task<BuyTicketSummary> Buy(ITIcketCreation ticket);
    }
}
