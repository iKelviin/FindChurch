using FindChurch.Application.Models;
using FindChurch.Core.Repositories;
using MediatR;

namespace FindChurch.Application.Commands.ChurchCommands.CreateChurch;

public class CreateChurchCommandHandler : IRequestHandler<CreateChurchCommand, ResultViewModel<Guid>>
{
    private readonly IChurchRepository _churchRepository;

    public CreateChurchCommandHandler(IChurchRepository churchRepository)
    {
        _churchRepository = churchRepository;
    }

    public async Task<ResultViewModel<Guid>> Handle(CreateChurchCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var church = request.ToEntity();
            await _churchRepository.AddAsync(church);
            return ResultViewModel<Guid>.Success(church.Id);
        }
        catch (Exception e)
        {
            return ResultViewModel<Guid>.Error($"Error occured: {e.Message}");
        }
    }
}