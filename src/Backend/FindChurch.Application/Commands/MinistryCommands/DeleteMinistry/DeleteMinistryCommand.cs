using FindChurch.Application.Models;
using MediatR;

namespace FindChurch.Application.Commands.MinistryCommands.DeleteMinistry;

public class DeleteMinistryCommand : IRequest<ResultViewModel>
{
    public Guid Id { get; set; }
}