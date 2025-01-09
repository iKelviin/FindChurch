using FindChurch.Core.Entities;
using FindChurch.Core.Enums;

namespace FindChurch.Application.Models;

public class WorshipServiceViewModel
{
    public WorshipServiceViewModel(Guid id,Guid idChurch,string churchName, DayOfWeek day, string time, TypeWorship service)
    {
        Id = id;
        IdChurch = idChurch;
        ChurchName = churchName;
        Day = day;
        Time = time;
        Service = service;
    }
    public Guid Id { get; private set; }
    public Guid IdChurch { get; private set; }
    public string ChurchName  { get; private set; }
    public DayOfWeek Day { get; private set; }
    public string Time { get; private set; }
    public TypeWorship Service { get; private set; }

    public static WorshipServiceViewModel FromEntity(WorshipService worshipService)
    {
        return new(
            worshipService.Id,
            worshipService.Church.Id,
            worshipService.Church.Name,
            worshipService.Day,
            worshipService.Time,
            worshipService.Service
        );
    }
}