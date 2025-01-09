using FindChurch.Core.Entities;
using FindChurch.Core.Enums;

namespace FindChurch.Application.Models;

public class MinistryMemberViewModel
{
    public MinistryMemberViewModel(Guid id, string name, MinistryRole role)
    {
        Id = id;
        Name = name;
        Role = role;
    }


    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public MinistryRole Role { get; private set; }

    public static MinistryMemberViewModel FromEntity(MinistryMember ministryMember)
    {
        return new(ministryMember.Id,ministryMember.Name, ministryMember.Role);
    }
}