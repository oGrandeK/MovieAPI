using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Enumerators;
using MovieAPI.Domain.Validation;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Tests.MovieTests;

[TestClass]
public class MovieTests
{
    // [TestMethod]
    // public void ShouldReturnDomainExceptionValidationWhenMovieTitleIsNull() {
    //     Assert.ThrowsException<DomainExceptionValidation>(() => 
    //     {
    //         var movie = new Movie(null, null, null, null, null, null,1);
    //     });
    // }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenMovieTitleHasLessThan2CharacterLong() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var movie = new Movie(new Title("T"), null, null, null, null, null, 1);
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenMovieTitleHasMoreThan50CharactersLong() {
        Assert.ThrowsException<DomainExceptionValidation>(() =>
        {
            var movie = new Movie(new Title("AaaaaaaaaaaaaaaaaaaaaAaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"), null, null, null, null, null, 1);
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenMovieTitleIsEmpty() {
        Assert.ThrowsException<DomainExceptionValidation>(() =>
        {
            var movie = new Movie(new Title(""), null, null, null, null, null, 1);
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenMovieTitleIsWhiteSpace() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var movie = new Movie(new Title(" "), null, null, null, null, null, 1);
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenMovieTitleHasSpecialCharacter() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var movie = new Movie(new Title("T@y St@ry"), null, null, null, null, null, 1);
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenMovieDescriptionHasLessThan10Characters() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var movie = new Movie(new Title("Toy Story"), "An Am", null, null, null, null, 1);
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenMovieDescriptionHasMoreThan255CharactersLong() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var movie = new Movie(new Title("Toy Story"), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc, quis gravida magna mi a libero. Fusce vulputate eleifend sapien. Vestibulum purus quam, scelerisque ut, mollis sed, nonummy id, metus. Nullam accumsan lorem in dui. Cras ultricies mi eu turpis hendrerit fringilla. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; In ac dui quis mi consectetuer lacinia. Nam pretium turpis et", null, null, null, null, 1);
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenMovieGenreDoesntExist() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var movie = new Movie(new Title("Toy Story"), "An amazing movie to watch with your family", (GenreEnumerator)7, null, null, null, 1);
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenMovieDurationHasLessThan0Minutes() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var movie = new Movie(new Title("Toy Story"), "An amazing movie to watch with your family", GenreEnumerator.Comedy, -1, null, null, 1);
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenMovieDurationHasMoreThan600Minutes() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
           var movie = new Movie(new Title("Toy Story"), "An amazing movie to watch with your family", GenreEnumerator.Comedy, 601, null, null, 1); 
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenMovieReleaseDateAreInferiorThan19851228() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var movie = new Movie(new Title("Toy Story"), "An amazing movie to watch with your family", GenreEnumerator.Comedy, 120, new DateTime(1984, 12, 28), null, 1);
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenMovieRatingHasLessThan0() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var movie = new Movie(new Title("Toy Story"), "An amazing movie to watch with your family", GenreEnumerator.Comedy, 120, new DateTime(2019, 05, 15), -1, 1);
        });
    }

    //[TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenMovieDirectorIsNull() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var movie = new Movie(new Title("Toy Story"), "An amazing movie", null, null, null, null, 10);
        });
    }
}