using LanguageExt;

namespace Uobachi.Tests;

[TestClass]
public class FishbowlStateReducerTest
{
    [TestMethod]
    public void AddUser_WithNew_AddsUserInAudienceToFishbowl()
    {
        // Arrange
        var state = FishbowlCoreState.New;
        var userId = UserId.New();
        var action = FishbowlStateAction.AddUser(userId);
        var expected = FishbowlCoreState.New with
        {
            Users = [
                User.New(userId),
            ],
            Audience = [
                userId,
            ],
        };

        // Act
        var result = state.Apply(action);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [TestMethod]
    public void AddUser_WithUserInAudience_AddsUserInAudienceToFishbowl()
    {
        // Arrange
        var existingUserId = UserId.New();
        var state = FishbowlCoreState.New with
        {
            Users = [
                User.New(existingUserId),
            ],
            Audience = [
                existingUserId,
            ],
        };
        var userId = UserId.New();
        var action = FishbowlStateAction.AddUser(userId);
        var expected = state with
        {
            Users = [
                ..state.Users,
                User.New(userId),
            ],
            Audience = [
                ..state.Audience,
                userId,
            ],
        };

        // Act
        var result = state.Apply(action);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void SwitchPosition_WithUserInAudience_MovesUserToBowl()
    {
        // Arrange
        var userId = UserId.New();
        var action = FishbowlStateAction.SwitchPosition(userId);
        var state = FishbowlCoreState.New with
        {
            Users = [
                User.New(userId),
            ],
            Audience = [
                userId,  
            ],
        };
        var expected = FishbowlCoreState.New with
        {
            Users = [
                User.New(userId),
            ],
            Bowl = [
                userId,  
            ],
        };

        // Act
        var result = state.Apply(action);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void SwitchPosition_WithUserInBowl_MovesUserToAudience()
    {
        // Arrange
        var userId = UserId.New();
        var action = FishbowlStateAction.SwitchPosition(userId);
        var state = FishbowlCoreState.New with
        {
            Users = [
                User.New(userId),
            ],
            Bowl = [
                userId,  
            ],
        };
        var expected = FishbowlCoreState.New with
        {
            Users = [
                User.New(userId),
            ],
            Audience = [
                userId,  
            ],
        };

        // Act
        var result = state.Apply(action);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    [DataRow(1, 3)]
    [DataRow(3, 5)]
    [DataRow(10, 3)]
    [DataRow(100, 300)]
    [DataRow(15, 15)]
    public void ConfigureSeats_WithNewSeats_SetsSeats(int seats, int newSeats)
    {
        // Arrange
        var action = FishbowlStateAction.ConfigureSeats(newSeats);
        var state = FishbowlCoreState.New with
        {
            Config = FishbowlCoreState.New.Config with
            {
                Seats = seats,
            },
        };
        var expected = new
        {
            Config = new
            {
                Seats = newSeats,
            },
        };

        // Act
        var result = state.Apply(action);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}