namespace MovieAPI.Domain.Tests;

[TestClass]
public class MovieReleaseDateTests
{
    [TestMethod]
    public void ShouldReturnFailWhenReleaseDateAreInferiorThanFirstMovieMade() {
        var releaseDate = new DateTime(1984, 12, 28);

        Assert.IsTrue(releaseDate < new DateTime(1985, 12, 28), "Release date must be inferior than 1985-12-28");
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenReleaseDateIsValid() {
        var releaseDate = new DateTime(2018, 05, 16);

        Assert.IsTrue(releaseDate > new DateTime(1985, 12, 28), "Release date must be greater than 1985-12-28");
    }
}