using MovieAPI.Domain.Entities;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Tests.DirectorTests;

[TestClass]
public class DirectorMoviesTests
{

    [TestMethod]
    public void ShouldReturnFailWhenMoviesIsEmpty() {
        var director = new Director(new Name("Armando", "Nogueira"));
        
        Assert.IsTrue(director.Movies.Count == 0, "Movies must be empty");
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenMoviesAreNotNull() {
        var director = new Director(new Name("Armando", "Nogueira"));
        var movie = new Movie(new Title("Whiplash"), "An amazing movie", Enumerators.GenreEnumerator.Drama, 160, new DateTime(2019,12,23), 9.9, 1);

        director.Movies.Add(movie);
        
        Assert.IsTrue(director.Movies.Count > 0, "Director must have at least one movie");
    }
}