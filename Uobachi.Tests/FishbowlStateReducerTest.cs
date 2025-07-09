namespace Uobachi.Tests;

[TestClass]
public class FishbowlStateReducerTest
{
    [TestMethod]
    public void AddUser_WithNew_AddsUserInAudienceToFishbowl()
    {
        // Arrange
        var state = FishbowlState.New;
        var userId = UserId.New();
        var expected = FishbowlState.New with
        {
            Users = [
                User.New(userId),
            ],
            Audience = [
                userId,
            ],
        };

        // Act
        var result = state.AddUser(userId);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void SwitchPosition_WithUserInAudience_MovesUserToBowl()
    {
        // Arrange
        var userId = UserId.New();
        var state = FishbowlState.New with
        {
            Users = [
                User.New(userId),
            ],
            Audience = [
                userId,  
            ],
        };
        var expected = FishbowlState.New with
        {
            Users = [
                User.New(userId),
            ],
            Bowl = [
                userId,  
            ],
        };

        // Act
        var result = state.SwitchPosition(userId);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void SwitchPosition_WithUserInBowl_MovesUserToAudience()
    {
        // Arrange
        var userId = UserId.New();
        var state = FishbowlState.New with
        {
            Users = [
                User.New(userId),
            ],
            Bowl = [
                userId,  
            ],
        };
        var expected = FishbowlState.New with
        {
            Users = [
                User.New(userId),
            ],
            Audience = [
                userId,  
            ],
        };

        // Act
        var result = state.SwitchPosition(userId);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}