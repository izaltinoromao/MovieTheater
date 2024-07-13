namespace MovieTheater.Responses
{
    public record TicketResponse(int id, string ownerName, DateTime date, int movieTheaterId, string movieTheaterName);
}
