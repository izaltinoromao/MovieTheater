namespace MovieTheater.Requests
{
    public record TicketEditRequest(int id, string ownerName, int movieTheaterId);
}
