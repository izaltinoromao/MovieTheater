namespace MovieTheater.Requests
{
    public record ParkingDetailEditRequest(int id, int numberOfSpaces, bool isCovered, bool hasEVChargingStations, int movieTheaterId);
}
