using FindChurch.Application.Commands.ChurchCommands.CreateChurch;
using FindChurch.Application.Commands.WorshipServiceCommands.CreateWorshipService;
using FindChurch.Core.Entities;
using FindChurch.Core.Enums;
using FindChurch.Core.Repositories;
using Moq;

namespace FindChurch.Tests.Application.Command;

public class CreateWorshipServiceHandlerTests
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
        church.Id = Guid.NewGuid();
        var worshipService = new WorshipService(church.Id,DayOfWeek.Sunday,"19:30",TypeWorship.OfficialWorship);

        var ChurchRepositoryMock = new Mock<IChurchRepository>();
        ChurchRepositoryMock.Setup(b => b.GetByIdAsync(church.Id).Result).Returns(church);
        
        var WorshipRepositoryMock = new Mock<IWorshipRepository>();
        WorshipRepositoryMock.Setup(w => w.GetByIdAsync(worshipService.Id)).ReturnsAsync(worshipService);
        
        var createWorshipServiceCommand = new CreateWorshipServiceCommand(worshipService.IdChurch,worshipService.Day,worshipService.Time,worshipService.Service);
        var createWorshipServiceCommandHandler = new CreateWorshipServiceCommandHandler(WorshipRepositoryMock.Object,ChurchRepositoryMock.Object);
        
        // Act
        var result = await createWorshipServiceCommandHandler.Handle(createWorshipServiceCommand, CancellationToken.None);
        
        // Assert
        Assert.True(result.IsSuccess);
        WorshipRepositoryMock.Verify(w => w.AddAsync(It.IsAny<WorshipService>()), Times.Once);
    }
}