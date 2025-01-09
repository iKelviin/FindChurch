using FindChurch.Application.Models;
using FindChurch.Core.Repositories;
using MediatR;

namespace FindChurch.Application.Queries.MinistryQueries.GetAllMinistries;

public class GetAllMinistriesQueryHandler : IRequestHandler<GetAllMinistriesQuery, ResultViewModel<List<MinistryViewModel>>>
{
    private readonly IMinistryRepository _repository;

    public GetAllMinistriesQueryHandler(IMinistryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<List<MinistryViewModel>>> Handle(GetAllMinistriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var ministries = await _repository.GetAllAsync();
            var model = ministries.Select(MinistryViewModel.FromEntity).ToList();
            return new ResultViewModel<List<MinistryViewModel>>(model);
        }
        catch (Exception e)
        {
            return ResultViewModel<List<MinistryViewModel>>.Error($"Error occured: {e.Message}");
        }
    }
}