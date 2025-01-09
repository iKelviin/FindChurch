using FindChurch.Application.Models;
using MediatR;

namespace FindChurch.Application.Queries.WorshipServiceQueries.GetAllWorshipServicesByIdChurch;

public class GetAllWorshipServicesByIdChurchQuery : IRequest<ResultViewModel<List<WorshipServiceViewModel>>>
{
    public GetAllWorshipServicesByIdChurchQuery(Guid idChurch)
    {
        IdChurch = idChurch;
    }

    public Guid IdChurch { get; set; }
}