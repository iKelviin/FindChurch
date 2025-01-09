using FindChurch.Core.Enums;

namespace FindChurch.Core.Entities;

public class WorshipService : BaseEntity
{
    protected WorshipService() { }
    public WorshipService(Guid idChurch, DayOfWeek day, string time, TypeWorship service) : base()
    {
        IdChurch = idChurch;
        Day = day;
        Time = time;
        Service = service;
    }

    public Guid IdChurch { get; private set; }
    public Church Church { get; private set; }
    public DayOfWeek Day { get; private set; }
    public string Time { get; private set; }
    public TypeWorship Service { get; private set; }

    public void Update(DayOfWeek day, string time, TypeWorship service)
    {
        Day = day;
        Time = time;
        Service = service;
    }
}