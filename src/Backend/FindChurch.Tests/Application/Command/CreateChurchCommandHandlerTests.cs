using FindChurch.Application.Commands.ChurchCommands.CreateChurch;
using FindChurch.Core.Entities;
using FindChurch.Core.Repositories;
using Moq;

namespace FindChurch.Tests.Application.Command;

public class CreateChurchCommandHandlerTests
{
    [Fact]
    public async Task InputDataIsOk_Execute_ReturnsSuccessCode()
    {
        //Arrange
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
        ChurchRepositoryMock.Setup(b => b.GetByIdAsync(church.Id).Result).Returns(church);
        
        var createChurchCommand = new CreateChurchCommand(
            church.Name,
            church.Street,
            church.City,
            church.State,
            church.ZipCode,
            church.Number,
            church.Location.X,
            church.Location.Y,
            church.PhoneNumbers
        );
        
        var createChurchCommandHandler = new CreateChurchCommandHandler(ChurchRepositoryMock.Object);

        // Act
        var result = await createChurchCommandHandler.Handle(createChurchCommand, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        ChurchRepositoryMock.Verify(l => l.AddAsync(It.IsAny<Church>()), Times.Once());
    }
}