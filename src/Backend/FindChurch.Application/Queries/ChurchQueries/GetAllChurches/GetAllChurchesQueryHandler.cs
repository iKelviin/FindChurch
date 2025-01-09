using FindChurch.Application.Models;
using FindChurch.Core.Repositories;
using MediatR;

namespace FindChurch.Application.Queries.ChurchQueries.GetAllChurches;

public class GetAllChurchesQueryHandler : IRequestHandler<GetAllChurchesQuery, ResultViewModel<List<ChurchViewModel>>>
{
    private readonly IChurchRepository _churchRepository;

    public GetAllChurchesQueryHandler(IChurchRepository churchRepository)
    {
        _churchRepository = churchRepository;
    }

    public async Task<ResultViewModel<List<ChurchViewModel>>> Handle(GetAllChurchesQuery request, CancellationToken cancellationToken)
    {
        var churches = await _churchRepository.GetAllAsync();
        
        var model = churches.Select(ChurchViewModel.FromEntity).ToList();
        
        return ResultViewModel<List<ChurchViewModel>>.Success(model);
    }
}