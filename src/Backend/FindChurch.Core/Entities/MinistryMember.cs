using FindChurch.Core.Enums;

namespace FindChurch.Core.Entities;

public class MinistryMember : BaseEntity
{
    public MinistryMember(Guid idMinistry, string name, MinistryRole role) : base()
    {
        IdMinistry = idMinistry;
        Name = name;
        Role = role;
    }


    public Guid IdMinistry { get; private set; }
    public string Name { get; private set; }
    public MinistryRole Role { get; private set; }
}