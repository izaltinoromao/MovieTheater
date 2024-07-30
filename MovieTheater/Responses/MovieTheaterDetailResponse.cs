using MovieTheater_Console;

namespace MovieTheater.Responses
{
    public record MovieTheaterDetailResponse(int id, 
        string name, 
        string address, 
        ParkingDetailMovieTheaterResponse parkingDetail, 
        ICollection<MovieMovieTheaterResponse> staringMovies, 
        ICollection<TicketMovieTheaterResponse> validTickets);
}
