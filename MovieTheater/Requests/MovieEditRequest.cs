using MovieTheater_Console;

namespace MovieTheater.Requests
{
    public record MovieEditRequest(int id, string name, int duration, ICollection<int> MovieTheaterIds);
}
