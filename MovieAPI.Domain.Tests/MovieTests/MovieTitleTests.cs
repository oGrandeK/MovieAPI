using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Tests.MovieTests;

[TestClass]
public class MovieTests
{
    [TestMethod]
    public void ShouldReturnSuccessWhenTitleIsValid() {
        var title = new Title("Toy Story");

        Assert.IsTrue(title.MovieTitle is not null, "Title msut be valid");
    }

    [TestMethod]
    public void ShouldReturnFailWhenTitleHasMoreThanTwentyCharacters() {
        var title = new Title("aaaaaaaaaaaaaaaaaaaa");

        Assert.IsTrue(title.MovieTitle.Length >= 20, "Expected the length of movie title to be less than 20 characters");
    }

    [TestMethod]
    public void ShouldReturnFailWhenTitleHasLessThanOneCharacters() {
        var title = new Title("a");

        Assert.IsTrue(title.MovieTitle.Length <= 1, "Expected the length of movie title to be greater than 1 character");
    }
}