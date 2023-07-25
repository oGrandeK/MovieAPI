using MovieAPI.Domain.Entities;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Tests.DirectorTests;

[TestClass]
public class DirectorMoviesTests
{
    [TestMethod]
    public void ShouldReturnFailWhenMoviesIsEmpty() {
        var director = new Director(new Name("Armando", "Nogueira"));
        
        Assert.IsTrue(director.Movies.Count == 0);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenMoviesIsNotNull() {
        var director = new Director(new Name("Armando", "Nogueira"));
        var movie = new Movie(new Title("Whiplash"), new Description("Amazing Movie"), Enumerators.GenreEnumerator.Drama, 120, DateOnly.FromDateTime(DateTime.UtcNow), 9.0, 1);
        director.Movies.Add(movie);

        Assert.IsTrue(director.Movies.Count > 0);
    }
}