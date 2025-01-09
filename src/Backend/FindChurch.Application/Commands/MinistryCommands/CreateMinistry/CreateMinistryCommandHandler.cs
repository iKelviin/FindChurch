using FindChurch.Application.Models;
using FindChurch.Core.Repositories;
using MediatR;

namespace FindChurch.Application.Commands.MinistryCommands.CreateMinistry;

public class CreateMinistryCommandHandler : IRequestHandler<CreateMinistryCommand, ResultViewModel<Guid>>
{
    private readonly IMinistryRepository _ministryRepository;
    private readonly IChurchRepository _churchRepository;

    public CreateMinistryCommandHandler(IMinistryRepository ministryRepository, IChurchRepository churchRepository)
    {
        _ministryRepository = ministryRepository;
        _churchRepository = churchRepository;
    }

    public async Task<ResultViewModel<Guid>> Handle(CreateMinistryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var church = await _churchRepository.GetByIdAsync(request.IdChurch);
            if(church is null) return ResultViewModel<Guid>.Error("Church not found");

            var ministry = request.ToEntity();
            await _ministryRepository.AddAsync(ministry);
            return ResultViewModel<Guid>.Success(ministry.Id);

        }
        catch (Exception e)
        {
            return ResultViewModel<Guid>.Error($"Error occured: {e.Message}");
        }
    }
}