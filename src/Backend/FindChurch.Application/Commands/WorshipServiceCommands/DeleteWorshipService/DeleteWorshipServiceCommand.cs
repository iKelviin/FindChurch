using FindChurch.Application.Models;
using MediatR;

namespace FindChurch.Application.Commands.WorshipServiceCommands.DeleteWorshipService;

public class DeleteWorshipServiceCommand : IRequest<ResultViewModel>
{
    public DeleteWorshipServiceCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}