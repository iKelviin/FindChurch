using FindChurch.Application.Models;
using FindChurch.Core.Entities;
using FindChurch.Core.Enums;
using MediatR;

namespace FindChurch.Application.Commands.MinistryCommands.UpdateMinistry;

public class UpdateMinistryCommand : IRequest<ResultViewModel>
{
    public Guid Id { get; set; }
    public List<UpdateMinistryMember> Members { get; set; }
}

public class UpdateMinistryMember
{
    public string Name { get;  set; }
    public MinistryRole Role { get; set; }
}