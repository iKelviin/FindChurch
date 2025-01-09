using FindChurch.Application.Models;
using FindChurch.Core.Entities;
using MediatR;

namespace FindChurch.Application.Commands.ChurchCommands.UpdateChurch;

public class UpdateChurchCommand : IRequest<ResultViewModel>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public int Number { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public List<string> PhoneNumbers { get; set; }
}