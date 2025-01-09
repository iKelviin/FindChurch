using FindChurch.Application.Models;
using FindChurch.Core.Repositories;
using MediatR;

namespace FindChurch.Application.Commands.MinistryCommands.DeleteMinistry;

public class DeleteMinistryCommandHandler : IRequestHandler<DeleteMinistryCommand, ResultViewModel>
{
    private readonly IMinistryRepository _ministryRepository;
    public DeleteMinistryCommandHandler(IMinistryRepository ministryRepository)
    {
        _ministryRepository = ministryRepository;
    }
    
    public async Task<ResultViewModel> Handle(DeleteMinistryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var ministry = await _ministryRepository.GetByIdAsync(request.Id);
            if (ministry is null) return ResultViewModel.Error("Ministry not found");

            ministry.SetAsDeleted();
            await _ministryRepository.UpdateAsync(ministry);
            return ResultViewModel.Success();
        }
        catch (Exception e)
        {
            return ResultViewModel.Error($"Error occured: {e.Message}");
        }
    }
}