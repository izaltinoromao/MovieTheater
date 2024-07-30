namespace MovieTheater.Responses
{
    public record ParkingDetailResponse(int id, 
        int numberOfSpaces, 
        bool isCovered, 
        bool hasEVChargingStations, 
        int movieTheaterId, 
        string movieTheaterName);

    public record ParkingDetailMovieTheaterResponse(int id,
        int numberOfSpaces,
        bool isCovered,
        bool hasEVChargingStations);
}
