using FindChurch.Application.Models;
using MediatR;

namespace FindChurch.Application.Queries.MinistryQueries.GetAllMinistriesByIdChurch;

public class GetAllMinistriesByIdChurchQuery : IRequest<ResultViewModel<List<MinistryViewModel>>>
{
    public GetAllMinistriesByIdChurchQuery(Guid idChurch)
    {
        IdChurch = idChurch;
    }

    public Guid IdChurch { get; set; }
}