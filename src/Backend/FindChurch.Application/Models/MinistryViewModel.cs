using FindChurch.Core.Entities;
using FindChurch.Core.Enums;

namespace FindChurch.Application.Models;

public class MinistryViewModel
{
    public MinistryViewModel(Guid id,Guid idChurch, string churchName, List<MinistryMemberViewModel> members)
    {
        Id = id;
        IdChurch = idChurch;
        ChurchName = churchName;
        Members = members;
    }

    public Guid Id { get; set; }
    public Guid IdChurch { get; private set; }
    public string ChurchName { get; private set; }
    public List<MinistryMemberViewModel> Members { get; private set; }

    public static MinistryViewModel FromEntity(Ministry ministry)
    {
        return new(ministry.Id,ministry.IdChurch,ministry.Church.Name, ministry.Members.Select(MinistryMemberViewModel.FromEntity).ToList());
    }
}