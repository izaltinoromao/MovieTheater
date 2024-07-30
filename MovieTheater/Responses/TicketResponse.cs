namespace MovieTheater.Responses
{
    public record TicketResponse(int id, 
        string ownerName, 
        DateTime date, 
        int movieTheaterId, 
        string movieTheaterName);

    public record TicketMovieTheaterResponse(int id,
        string ownerName,
        DateTime purchaseDate,
        DateTime expireAt);
}
