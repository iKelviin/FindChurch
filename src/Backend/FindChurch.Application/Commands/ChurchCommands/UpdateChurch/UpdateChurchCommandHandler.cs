using FindChurch.Application.Models;
using FindChurch.Core.Repositories;
using MediatR;

namespace FindChurch.Application.Commands.ChurchCommands.UpdateChurch;

public class UpdateChurchCommandHandler : IRequestHandler<UpdateChurchCommand, ResultViewModel>
{
    private readonly IChurchRepository _churchRepository;

    public UpdateChurchCommandHandler(IChurchRepository churchRepository)
    {
        _churchRepository = churchRepository;
    }

    public async Task<ResultViewModel> Handle(UpdateChurchCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var church = await _churchRepository.GetByIdAsync(request.Id);
            if (church is null) return ResultViewModel.Error("Church not found.");

            church.Update(request.Name,
                request.Street,
                request.City,
                request.State,
                request.ZipCode,
                request.Number,
                request.Latitude,
                request.Longitude,
                request.PhoneNumbers);
            
            await _churchRepository.UpdateAsync(church);

            return ResultViewModel.Success();
        }
        catch (Exception e)
        {
            return ResultViewModel.Error($"Error occured: {e.Message}");
        }
    }
}