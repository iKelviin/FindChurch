using FindChurch.Application.Models;
using FindChurch.Core.Entities;
using FindChurch.Core.Repositories;
using MediatR;

namespace FindChurch.Application.Queries.WorshipServiceQueries.GetAllWorshipServicesByIdChurch;

public class GetAllWorshipServicesByIdChurchQueryHandler : IRequestHandler<GetAllWorshipServicesByIdChurchQuery, ResultViewModel<List<WorshipServiceViewModel>>>
{
    private readonly IWorshipRepository _worshipRepository;
    private readonly IChurchRepository _churchRepository;

    public GetAllWorshipServicesByIdChurchQueryHandler(IWorshipRepository worshipRepository, IChurchRepository churchRepository)
    {
        _worshipRepository = worshipRepository;
        _churchRepository = churchRepository;
    }

    public async Task<ResultViewModel<List<WorshipServiceViewModel>>> Handle(GetAllWorshipServicesByIdChurchQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var church = await _churchRepository.GetByIdAsync(request.IdChurch);
            if (church is null) return ResultViewModel<List<WorshipServiceViewModel>>.Error("Church not found");

            var worshipServices = await _worshipRepository.GetAllByIdChurchAsync(request.IdChurch);
            var model = worshipServices.Select(WorshipServiceViewModel.FromEntity).ToList();
            return ResultViewModel<List<WorshipServiceViewModel>>.Success(model);
        }
        catch (Exception e)
        {
            return ResultViewModel<List<WorshipServiceViewModel>>.Error($"Error occured: {e.Message}");
        }
    }
}