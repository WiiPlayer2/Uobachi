namespace Uobachi.Tests;

[TestClass]
public class FishbowlStateReducerTest
{
    [TestMethod]
    public void AddUser_WithNew_AddsUserInAudienceToFishbowl()
    {
        // Arrange
        var initialState = FishbowlState.New;
        var userId = UserId.New();
        var expectedState = FishbowlState.New with
        {
            Users = [
                User.New(userId),
            ],
            Audience = [
                userId,
            ],
        };

        // Act
        var result = initialState.AddUser(userId);

        // Assert
        result.Should().BeEquivalentTo(expectedState);
    }
}