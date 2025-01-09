using FindChurch.Application.Models;
using FindChurch.Core.Entities;
using MediatR;

namespace FindChurch.Application.Commands.ChurchCommands.CreateChurch;

public class CreateChurchCommand : IRequest<ResultViewModel<Guid>>
{
    public CreateChurchCommand(string name, string street, string city, string state, string zipCode, int number, double latitude, double longitude, List<string> phoneNumbers)
    {
        Name = name;
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
        Number = number;
        Latitude = latitude;
        Longitude = longitude;
        PhoneNumbers = phoneNumbers;
    }

    public string Name { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public int Number { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
    public List<string> PhoneNumbers { get; private set; }

    public Church ToEntity()
    {
        return new(
            Name,
            Street,
            City,
            State,
            ZipCode,
            Number,
            Latitude,
            Longitude,
            PhoneNumbers
        );
    }
}