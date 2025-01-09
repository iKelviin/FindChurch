using FindChurch.Application.Models;
using FindChurch.Core.Repositories;
using MediatR;

namespace FindChurch.Application.Commands.ChurchCommands.DeleteChurch;

public class DeleteChurchCommandHandler : IRequestHandler<DeleteChurchCommand, ResultViewModel>
{
    private readonly IChurchRepository _churchRepository;

    public DeleteChurchCommandHandler(IChurchRepository churchRepository)
    {
        _churchRepository = churchRepository;
    }

    public async Task<ResultViewModel> Handle(DeleteChurchCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var church = await _churchRepository.GetByIdAsync(request.Id);
            if (church is null) return ResultViewModel.Error("Church not found");

            church.SetAsDeleted();
            await _churchRepository.UpdateAsync(church);
            return ResultViewModel.Success();
        }
        catch (Exception e)
        {
            return ResultViewModel.Error($"Error occured: {e.Message}");
        }
    }
}