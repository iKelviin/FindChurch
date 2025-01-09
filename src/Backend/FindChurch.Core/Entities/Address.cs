using NetTopologySuite.Geometries;

namespace FindChurch.Core.Entities;

public class Address
{
    public Address(string street, string city, string state, string zipCode, int number, double latitude, double longitude)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        Number = number;
        Location = SetLocation(latitude, longitude);
    }

    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public int Number { get; private set; }
    public Point Location { get; private set; }

    private Point SetLocation(double Latitude, double Longitude)
    {
        return new Point(Latitude, Longitude){SRID = 4326};
    }
}