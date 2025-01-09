using FindChurch.Core.Entities;
using NetTopologySuite.Geometries;

namespace FindChurch.Application.Models;

public class ChurchViewModel
{
    public ChurchViewModel(Guid id, string name, string street, string city, string state, string zipCode, int number, Point location, List<string> phoneNumbers)
    {
        Id = id;
        Name = name;
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        Number = number;
        Latitude = location.X;
        Longitude = location.Y;
        PhoneNumbers = phoneNumbers;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public int Number { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
    public List<string> PhoneNumbers { get; private set; }

    public static ChurchViewModel FromEntity(Church church)
    {
        return new(
            church.Id,
            church.Name,
            church.Street,
            church.City,
            church.State,
            church.ZipCode,
            church.Number,
            church.Location,
            church.PhoneNumbers
        );
    }
}