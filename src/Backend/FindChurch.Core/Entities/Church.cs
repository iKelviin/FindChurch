using NetTopologySuite.Geometries;

namespace FindChurch.Core.Entities;

public class Church : BaseEntity
{
    public Church(string name, string street, string city, string state, string zipCode, int number, double latitude,double longitude, List<string> phoneNumbers)
    {
        Name = name;
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        Number = number;
        Location = SetLocation(latitude, longitude);
        PhoneNumbers = phoneNumbers;
        WorshipServices = [];
        Ministry = [];
    }

    protected Church() { }
   

    public string Name { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public int Number { get; private set; }
    public Point Location { get; private set; }
    public List<string> PhoneNumbers { get; private set; }
    public List<WorshipService> WorshipServices { get; private set; }
    public List<Ministry> Ministry { get; private set; }

    private Point SetLocation(double Latitude, double Longitude)
    {
        return new Point(Latitude, Longitude){SRID = 4326};
    }

    public void Update(string name, string street, string city, string state, string zipCode, int number, double latitude, double longitude, List<string> phoneNumbers)
    {
        Name = name;
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        Number = number;
        Location = SetLocation(latitude, longitude);
        PhoneNumbers = phoneNumbers;
    }
}