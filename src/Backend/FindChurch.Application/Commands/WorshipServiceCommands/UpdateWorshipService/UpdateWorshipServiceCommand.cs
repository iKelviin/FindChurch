using FindChurch.Application.Models;
using FindChurch.Core.Entities;
using FindChurch.Core.Enums;
using MediatR;

namespace FindChurch.Application.Commands.WorshipServiceCommands.UpdateWorshipService;

public class UpdateWorshipServiceCommand : IRequest<ResultViewModel>
{
    public Guid Id { get; set; }
    public Guid IdChurch { get; set; }
    public DayOfWeek Day { get; set; }
    public string Time { get; set; }
    public TypeWorship Service { get; set; }
}