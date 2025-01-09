using FindChurch.Application.Models;
using FindChurch.Core.Entities;
using FindChurch.Core.Enums;
using MediatR;

namespace FindChurch.Application.Commands.MinistryCommands.CreateMinistry;

public class CreateMinistryCommand : IRequest<ResultViewModel<Guid>>
{
    public CreateMinistryCommand(Guid idChurch, List<CreateMinistryMember> members)
    {
        IdChurch = idChurch;
        Members = members;
    }

    public Guid IdChurch { get; set; }
    public List<CreateMinistryMember> Members { get; set; }

    public Ministry ToEntity() => new(IdChurch, new List<MinistryMember>(Members.Select(member => member.ToEntity()).ToList()));
}