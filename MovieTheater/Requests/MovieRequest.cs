using MovieTheater_Console;

namespace MovieTheater.Requests
{
    public record MovieRequest(string name, int duration, ICollection<int> MovieTheaterIds);
}
