using FindChurch.Application.Models;
using FindChurch.Core.Repositories;
using MediatR;

namespace FindChurch.Application.Commands.WorshipServiceCommands.DeleteWorshipService;

public class DeleteWorshipServiceCommandHandler : IRequestHandler<DeleteWorshipServiceCommand, ResultViewModel>
{
    private readonly IWorshipRepository _worshipRepository;

    public DeleteWorshipServiceCommandHandler(IWorshipRepository worshipRepository)
    {
        _worshipRepository = worshipRepository;
    }

    public async Task<ResultViewModel> Handle(DeleteWorshipServiceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var worshipService = await _worshipRepository.GetByIdAsync(request.Id);
            if (worshipService == null) return ResultViewModel.Error("Worship service not found");

            worshipService.SetAsDeleted();
            await _worshipRepository.UpdateAsync(worshipService);
            return ResultViewModel.Success();
        }
        catch (Exception e)
        {
            return ResultViewModel.Error($"Error deleting worship service: {e.Message}");
        }
    }
}