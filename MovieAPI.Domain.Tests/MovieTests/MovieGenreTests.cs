namespace MovieAPI.Domain.Tests.MovieTests;

using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Enumerators;
using MovieAPI.Domain.ValueObjects;

[TestClass]
public class MovieGenreTests
{
    [TestMethod]
    public void ShouldReturnFailWhenGenreDoesntExist() {
        var genre = 7;

        Assert.IsTrue(!Enum.IsDefined(typeof(GenreEnumerator), genre), "Genre exist");
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(2)]
    [DataRow(3)]
    [DataRow(4)]
    [DataRow(5)]
    public void ShouldReturnSuccessWhenGenreExist(int dataGenre) {
        var genre = dataGenre;

        Assert.IsTrue(Enum.IsDefined(typeof(GenreEnumerator), genre), "Genre is invalid");
    }
}