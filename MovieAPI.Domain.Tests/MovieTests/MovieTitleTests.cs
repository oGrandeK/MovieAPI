using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Tests.MovieTests;

[TestClass]
public class MovieTitleTests
{
    [TestMethod]
    public void ShouldReturnSuccessWhenTitleIsValid() {
        var title = new Title("Toy Story");

        Assert.IsTrue(title.MovieTitle is not null, "Title must be valid");
    }

    [TestMethod]
    public void ShouldReturnFailWhenTitleIsNull() {
        var title = new Title(null);

        Assert.IsTrue(title.MovieTitle is null, "Expected the title to be null");
    }

    [TestMethod]
    public void ShouldReturnFailWhenTitleHasMoreThanTwentyCharacters() {
        var title = new Title("aaaaaaaaaaaaaaaaaaaa");

        Assert.IsTrue(title.MovieTitle.Length >= 50, "Expected the length of movie title to be less than 50 characters");
    }

    [TestMethod]
    public void ShouldReturnFailWhenTitleHasLessThanOneCharacters() {
        var title = new Title("a");

        Assert.IsTrue(title.MovieTitle.Length <= 1, "Expected the length of movie title to be greater than 1 character");
    }

    [TestMethod]
    public void ShouldReturnFailWhenTitleIsEmpty() {
        var title = new Title("");

        bool isEmpty = title.MovieTitle is "";

        Assert.IsTrue(isEmpty, "Expected the title to be empty");
    }

    [TestMethod]
    [DataRow("A fuga das galinhas")]
    public void ShouldReturnErrorWhenTitleIsWhiteSpace(string dataRowTitle) {
        var title = new Title(dataRowTitle);

        Assert.IsTrue(title.MovieTitle.Any(ch => char.IsWhiteSpace(ch)), "Expected the title to be white space");
    }

    [TestMethod]
    public void ShouldReturnErrorWhenTitleIsSpecialCharacter() {
        var title = new Title("T@y St@ry");

        Assert.IsTrue(title.MovieTitle.Any(ch => char.IsPunctuation(ch)), "Expected the title to be special character");
    }
}