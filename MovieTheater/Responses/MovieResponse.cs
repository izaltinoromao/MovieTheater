namespace MovieTheater.Responses
{
    public record MovieResponse(int id, 
        string name, 
        int duration, 
        ICollection<MovieTheaterResponse> movieTheaters);

    public record MovieMovieTheaterResponse(
        int id,
        string name,
        int duration);
}
