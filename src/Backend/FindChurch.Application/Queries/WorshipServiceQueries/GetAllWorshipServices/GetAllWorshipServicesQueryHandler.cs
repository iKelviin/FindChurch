using FindChurch.Application.Models;
using FindChurch.Core.Entities;
using FindChurch.Core.Repositories;
using MediatR;

namespace FindChurch.Application.Queries.WorshipServiceQueries.GetAllWorshipServices;

public class GetAllWorshipServicesQueryHandler : IRequestHandler<GetAllWorshipServicesQuery, ResultViewModel<List<WorshipServiceViewModel>>>
{
    private readonly IWorshipRepository _worshipRepository;

    public GetAllWorshipServicesQueryHandler(IWorshipRepository worshipRepository)
    {
        _worshipRepository = worshipRepository;
    }

    public async Task<ResultViewModel<List<WorshipServiceViewModel>>> Handle(GetAllWorshipServicesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var worshipServices = await _worshipRepository.GetAllAsync();
            var model = worshipServices.Select(WorshipServiceViewModel.FromEntity).ToList();
            return new ResultViewModel<List<WorshipServiceViewModel>>(model);
        }
        catch (Exception e)
        {
            return ResultViewModel<List<WorshipServiceViewModel>>.Error($"Error occured: {e.Message}");
        }
    }
}