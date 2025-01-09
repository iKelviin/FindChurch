using FindChurch.Core.Entities;
using FindChurch.Core.Enums;

namespace FindChurch.Application.Models;

public class CreateMinistryMember
{
        public CreateMinistryMember(Guid idMinistry, string name, MinistryRole role)
        {
                IdMinistry = idMinistry;
                Name = name;
                Role = role;
        }

        public Guid IdMinistry { get; set; }
        public string Name { get; set; }
        public MinistryRole Role { get; set; }
    
        public MinistryMember ToEntity() => new(IdMinistry,Name, Role);
   
}