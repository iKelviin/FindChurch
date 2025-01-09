using FindChurch.Application.Models;
using MediatR;

namespace FindChurch.Application.Queries.MinistryQueries.GetAllMinistries;

public class GetAllMinistriesQuery : IRequest<ResultViewModel<List<MinistryViewModel>>>
{
    
}