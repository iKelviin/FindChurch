using FindChurch.Application.Models;
using MediatR;

namespace FindChurch.Application.Queries.WorshipServiceQueries.GetAllWorshipServices;

public class GetAllWorshipServicesQuery : IRequest<ResultViewModel<List<WorshipServiceViewModel>>>
{
    
}