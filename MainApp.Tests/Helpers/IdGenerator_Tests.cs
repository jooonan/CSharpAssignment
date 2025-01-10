using Business.Helpers;

namespace MainApp.Tests.Helpers;

/* This test is for generating and returning an ID*/
public class IdGenerator_Tests
{

    [Fact]
    public void Generate_ShouldReturnNewGuid()
    {
        // Act
        var result = IdGenerator.GenerateId();

        // Assert
        Assert.NotNull(result);
        Assert.True(Guid.TryParse(result, out _));
    }
}