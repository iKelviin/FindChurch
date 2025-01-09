using FindChurch.Application.Models;
using FindChurch.Core.Repositories;
using MediatR;

namespace FindChurch.Application.Queries.MinistryQueries.GetAllMinistriesByIdChurch;

public class GetAllMinistriesByIdChurchQueryHandler : IRequestHandler<GetAllMinistriesByIdChurchQuery, ResultViewModel<List<MinistryViewModel>>>
{
    private readonly IMinistryRepository _ministryRepository;
    private readonly IChurchRepository _churchRepository;
    
    public GetAllMinistriesByIdChurchQueryHandler(IMinistryRepository ministryRepository, IChurchRepository churchRepository)
    {
        _ministryRepository = ministryRepository;
        _churchRepository = churchRepository;
    }

    public async Task<ResultViewModel<List<MinistryViewModel>>> Handle(GetAllMinistriesByIdChurchQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var church = await _churchRepository.GetByIdAsync(request.IdChurch);
            if (church is null) return ResultViewModel<List<MinistryViewModel>>.Error("Church not found");

            var ministries = await _ministryRepository.GetAllByIdChurchAsync(request.IdChurch);

            var model = ministries.Select(MinistryViewModel.FromEntity).ToList();

            return ResultViewModel<List<MinistryViewModel>>.Success(model);
        }
        catch (Exception e)
        {
            return ResultViewModel<List<MinistryViewModel>>.Error($"Error occured: {e.Message}");
        }
    }
}