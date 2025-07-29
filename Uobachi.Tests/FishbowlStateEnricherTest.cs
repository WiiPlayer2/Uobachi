namespace Uobachi.Tests;

[TestClass]
public class FishbowlStateEnricherTest
{
    [TestMethod]
    public void Transform_WithState_ShouldCopyMembers()
    {
        // Arrange
        var state = FishbowlState.New;

        // Act
        var result = FishbowlStateEnricher.Transform(state);

        // Assert
        result.Should().BeEquivalentTo(state);
    }
    
    [TestMethod]
    [DataRow(1, 3, ValidStatus.TooFew)]
    [DataRow(2, 3, ValidStatus.TooFew)]
    [DataRow(100, 300, ValidStatus.TooFew)]
    [DataRow(1, 1, ValidStatus.Valid)]
    [DataRow(3, 3, ValidStatus.Valid)]
    [DataRow(300, 300, ValidStatus.Valid)]
    [DataRow(2, 1, ValidStatus.TooMany)]
    [DataRow(3, 2, ValidStatus.TooMany)]
    [DataRow(300, 200, ValidStatus.TooMany)]
    public void Transform_WithSpecifiedNumberOfUsersAndConfiguredSeats_ShouldSetCorrectValidStatus(int usersInBowl, int seats, ValidStatus expectedValidStatus)
    {
        // Arrange
        var userIds = Enumerable.Range(1, usersInBowl)
            .Select(_ => UserId.New())
            .ToArray();
        var state = FishbowlState.New with
        {
            Users = userIds.Select(User.New).ToList(),
            Config = FishbowlState.New.Config with
            {
                Seats = seats,
            },
            Bowl = userIds,
        };
        var expected = new
        {
            state.Users,
            state.Audience,
            state.Bowl,
            ValidStatus = expectedValidStatus,
        };

        // Act
        var result = FishbowlStateEnricher.Transform(state);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}