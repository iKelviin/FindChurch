using FindChurch.Application.Commands.MinistryCommands.CreateMinistry;
using FindChurch.Application.Commands.WorshipServiceCommands.CreateWorshipService;
using FindChurch.Application.Models;
using FindChurch.Core.Entities;
using FindChurch.Core.Enums;
using FindChurch.Core.Repositories;
using Moq;

namespace FindChurch.Tests.Application.Command;

public class CreateMinistryCommandHandlerTests
{
    [Fact]
    public async Task InputDataIsOk_Execute_ReturnsSuccessCode()
    {
        // Arrange
        var church = new Church(
            "Church Name",
            "Church Street",
            "Church City",
            "Church State",
            "Church ZipCode",
            123,
            -46.83412504959827,
            -23.55918336885141,
            ["+55 (11) 91234-5678", "+55 (11) 91234-5678"]
        );
        var ChurchRepositoryMock = new Mock<IChurchRepository>();
        var MinistryRepositoryMock = new Mock<IMinistryRepository>();
        ChurchRepositoryMock.Setup(b => b.GetByIdAsync(church.Id).Result).Returns(church);
        
        var idMinistry = Guid.NewGuid();
        var ministryMember2 = new CreateMinistryMember(idMinistry,"Ministry 2", MinistryRole.Elder);
        var ministryMember1 = new CreateMinistryMember(idMinistry,"Ministry 1", MinistryRole.Deacon);
        var ministryMember3 = new CreateMinistryMember(idMinistry,"Ministry 3", MinistryRole.OfficialCooperator);
        var ministryMember4 = new CreateMinistryMember(idMinistry,"Ministry 4", MinistryRole.YouthCooperator);
        
        var ministryMembers = new List<CreateMinistryMember>{ ministryMember1, ministryMember2, ministryMember3, ministryMember4 };

        var createMinistryCommand = new CreateMinistryCommand(church.Id,ministryMembers);
        var createMinistryCommandHandler = new CreateMinistryCommandHandler(MinistryRepositoryMock.Object,ChurchRepositoryMock.Object);
        
        // Act
        var result =  await createMinistryCommandHandler.Handle(createMinistryCommand, CancellationToken.None);
        
        // Assert
        Assert.True(result.IsSuccess);
        MinistryRepositoryMock.Verify(b => b.AddAsync(It.IsAny<Ministry>()), Times.Once);
    }
}