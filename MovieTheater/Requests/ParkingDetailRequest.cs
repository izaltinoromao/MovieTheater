namespace MovieTheater.Requests
{
    public record ParkingDetailRequest(int numberOfSpaces, bool isCovered, bool hasEVChargingStations, int movieTheaterId);
}
