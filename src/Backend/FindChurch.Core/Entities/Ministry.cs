using FindChurch.Core.Enums;

namespace FindChurch.Core.Entities;

public class Ministry : BaseEntity
{
    protected Ministry() { }
    public Ministry(Guid idChurch, List<MinistryMember> members)
    {
        IdChurch = idChurch;
        Members = members;
    }
    
    public Guid IdChurch { get; private set; }
    public List<MinistryMember> Members { get; private set; }
    public Church Church { get; private set; }

    public override void SetAsDeleted()
    {
        SetAsDeleted();
        if (Members.Count > 0)
        {
            foreach (var member in Members)
            {
                member.SetAsDeleted();
            }
        }
    }

    public void Update(List<MinistryMember> members)
    {
        Members = members;
    }
}