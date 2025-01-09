using FindChurch.Application.Models;
using FindChurch.Core.Entities;
using FindChurch.Core.Enums;
using MediatR;

namespace FindChurch.Application.Commands.WorshipServiceCommands.CreateWorshipService;

public class CreateWorshipServiceCommand : IRequest<ResultViewModel<Guid>>
{
    public CreateWorshipServiceCommand(Guid idChurch, DayOfWeek day, string time, TypeWorship typeWorship)
    {
        IdChurch = idChurch;
        Day = day;
        Time = time;
        TypeWorship = typeWorship;
    }

    public Guid IdChurch { get; set; }
    public DayOfWeek Day { get; set; }
    public string Time { get; set; }
    public TypeWorship TypeWorship { get; set; }
    
    public WorshipService ToEntity() => new(IdChurch, Day, Time, TypeWorship);
}