using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Tests.MovieTests;

[TestClass]
public class MovieTests
{
    [TestMethod]
    public void ShouldReturnFailWhenTitleIsNull() {
        var title = new Title(null);

        Assert.IsTrue(title.MovieTitle is null, "Title cannot be null");
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenTitleIsValid() {
        var title = new Title("Toy Story");

        Assert.IsTrue(title.MovieTitle is not null, "Title is valid");
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

    [TestMethod]
    public void ShouldReturnFailWhenDescriptionHasLessThanTenCharacters() {
        var description = new Description("aaaaaaaaaa");

        Assert.IsTrue(description.MovieDescription.Length <= 10, "Expected the length of movie description to be greater than 10 characters");
    }

    [TestMethod]
    public void ShouldReturnFailWhenDescriptionHasMoreThanTwoHundredFiftyFiveCharacters() {
        var description = new Description("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc, quis gravida magna mi a libero. Fusce vulputate eleifend sapien. Vestibulum purus quam, scelerisque ut, mollis sed, nonummy id, metus. Nullam accumsan lorem in dui. Cras ultricies mi eu turpis hendrerit fringilla. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; In ac dui quis mi consectetuer lacinia. Nam pretium turpis");

        Assert.IsTrue(description.MovieDescription.Length > 255, "Expected the length of movie description to be less than 255 characters");
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenDescriptionAreValid() {
        var description = new Description("A amazing movie to watch with your family");

        Assert.IsTrue(description.MovieDescription.Length > 10 && description.MovieDescription.Length <= 255, "Movie description are valid");
    }
}