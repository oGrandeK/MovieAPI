namespace MovieAPI.Domain.Tests.MovieTests;

[TestClass]
public class MovieDurationTests
{
    [TestMethod]
    [DataRow(-2)]
    [DataRow(0)]
    public void ShouldReturnFailWhenDurationIsLessOrEqualZero(int dur) {
        var duration = dur;

        Assert.IsTrue(duration <= 0, "Expected the duration be less or equal 0");
    }

    [TestMethod]
    public void ShouldReturnFailWhenDurationIsGreaterThan600Minutes() {
        var duration = 601;

        Assert.IsTrue(duration > 600, "Expected the duration be greater than 600 minutes");
    }
}