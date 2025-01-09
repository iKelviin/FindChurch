using FindChurch.Application.Models;
using FindChurch.Core.Repositories;
using MediatR;

namespace FindChurch.Application.Commands.WorshipServiceCommands.UpdateWorshipService;

public class UpdateWorshipServiceCommandHandler : IRequestHandler<UpdateWorshipServiceCommand, ResultViewModel>
{
    private readonly IWorshipRepository _worshipRepository;

    public UpdateWorshipServiceCommandHandler(IWorshipRepository worshipRepository)
    {
        _worshipRepository = worshipRepository;
    }

    public async Task<ResultViewModel> Handle(UpdateWorshipServiceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var worshipService = await _worshipRepository.GetByIdAsync(request.Id);
            if (worshipService == null) return ResultViewModel.Error("Worship Service not found");

            worshipService.Update(request.Day, request.Time, request.Service);
            await _worshipRepository.UpdateAsync(worshipService);
            return ResultViewModel.Success();
        }
        catch (Exception e)
        {
            return ResultViewModel.Error($"Error occured: {e.Message}");
        }
    }
}