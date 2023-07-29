namespace MovieAPI.Domain.Tests;

[TestClass]
public class MovieRatingTests
{
    [TestMethod]
    public void ShouldReturnFailWhenRatingIsLessThan0(){
        var rating = -1;

        Assert.IsTrue(rating < 0, "Expected the movie rating to be less than 0");
    }

    [TestMethod]
    [DataRow(0.1)]
    [DataRow(1)]
    [DataRow(5)]
    public void ShouldReturnSuccessWhenRatingIsValid(double rating) {
        Assert.IsTrue(rating > 0, "Expected the movie rating to be greater than 0");
    }
}