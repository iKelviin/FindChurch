using FindChurch.Application.Models;
using MediatR;

namespace FindChurch.Application.Commands.ChurchCommands.DeleteChurch;

public class DeleteChurchCommand : IRequest<ResultViewModel>
{
    public DeleteChurchCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}