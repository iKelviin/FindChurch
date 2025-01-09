using FindChurch.Application.Models;
using MediatR;

namespace FindChurch.Application.Queries.ChurchQueries.GetAllChurches;

public class GetAllChurchesQuery : IRequest<ResultViewModel<List<ChurchViewModel>>>
{
    
}