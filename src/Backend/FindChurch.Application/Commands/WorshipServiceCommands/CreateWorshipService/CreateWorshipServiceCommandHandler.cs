using FindChurch.Application.Models;
using FindChurch.Core.Repositories;
using MediatR;

namespace FindChurch.Application.Commands.WorshipServiceCommands.CreateWorshipService;

public class CreateWorshipServiceCommandHandler : IRequestHandler<CreateWorshipServiceCommand, ResultViewModel<Guid>>
{
    private readonly IWorshipRepository _worshipRepository;
    private readonly IChurchRepository _churchRepository;

    public CreateWorshipServiceCommandHandler(IWorshipRepository worshipRepository, IChurchRepository churchRepository)
    {
        _worshipRepository = worshipRepository;
        _churchRepository = churchRepository;
    }

    public async Task<ResultViewModel<Guid>> Handle(CreateWorshipServiceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var church = await _churchRepository.GetByIdAsync(request.IdChurch);
            if(church is null) return ResultViewModel<Guid>.Error("Church not found");
            
            var worship = request.ToEntity();
            await _worshipRepository.AddAsync(worship);
            return new ResultViewModel<Guid>(worship.Id);
        }
        catch (Exception e)
        {
            return ResultViewModel<Guid>.Error($"Error creating worship service: {e.Message}");
        }
    }
}