using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Tests.DirectorTests;

[TestClass]
public class DirectorNameTests
{
    [TestMethod]
    public void ShouldReturnFailWhenFirstNameIsWhiteSpace() {
        var name = new Name(" ", "Silva");

        Assert.IsTrue(name.FirstName.Any(ch => char.IsWhiteSpace(ch)), "Expected the first name to have white space");
    }

    [TestMethod]
    public void ShouldReturnFailWhenLastNameIsWhiteSpace() {
        var name = new Name("Aristoteles", " ");

        Assert.IsTrue(name.LastName.Any(ch => char.IsWhiteSpace(ch)), "Expected the last name to have white space");
    }

    [TestMethod]
    public void ShouldReturnErrorWhenFirstNameIsEmpty() {
        var name = new Name("", "Santos");

        bool isEmpty = name.FirstName is "";

        Assert.IsTrue(isEmpty, "Expected the first name to be empty");
    }

    [TestMethod]
    public void ShouldReturnErrorWhenLastNameIsEmpty() {
        var name = new Name("Teofilo", "");

        bool isEmpty = name.LastName is "";

        Assert.IsTrue(isEmpty, "Expected the last name to be empty");
    }

    [TestMethod]
    public void ShouldReturnFailWhenFirstNameHasThreeOrLessCharacters(){
        var name = new Name("a", "Silva");
        
        Assert.IsTrue(name.FirstName.Length <= 3, "Expected the length of the first name to be less than or equal to 3");
    }

    [TestMethod]
    public void ShouldReturnFailWhenLastNameHasThreeOrLessCharacters() {
        var name = new Name("Ana", "a");

        Assert.IsTrue(name.LastName.Length <= 3, "Expected the length of the last name to be less than or equal to 3");
    }

    [TestMethod]
    public void ShouldReturnFailWhenFirstNameHasMoreThanThirtyCharacters() {
        var name = new Name("asdeasdedsawdsawdsawdsawsdsaws", "Tonial");

        Assert.IsTrue(name.FirstName.Length >= 30, "Expected the length of the first name to be greater than 30 characters");
    }

    [TestMethod]
    public void ShouldReturnFailWhenLastNameHasMoreThanThirtyCharacters() {
        var name = new Name("Marcos", "asdeasdedsawdsawdsawdsawsdsaws");

        Assert.IsTrue(name.LastName.Length >= 30, "Expected the length of the last name to be less than 30 characters");
    }

    [TestMethod]
    public void ShouldReturnFailWhenFirstNameHasDigit() {
        var name = new Name("A1an", "Caio");

        Assert.IsTrue(name.FirstName.Any(ch => char.IsDigit(ch)), "Expected the first name to have a digit");
    }

    [TestMethod]
    public void ShouldReturnFailWhenLastNameHasDigit() {
        var name = new Name("Alan", "C4io");

        Assert.IsTrue(name.LastName.Any(ch => char.IsDigit(ch)), "Expected the last name to have a digit");
    }

    [TestMethod]
    public void ShouldReturnFailWhenFirstNameHasSpecialCharacter() {
        var name = new Name("Al@n", "Caio");

        Assert.IsTrue(name.FirstName.Any(ch => char.IsPunctuation(ch)), "Expected the first name to have a special character");
    }

    [TestMethod]
    public void ShouldReturnFailWhenLastNameHasSpecialCharacter() {
        var name = new Name("Alan", "C@io");

        Assert.IsTrue(name.LastName.Any(ch => char.IsPunctuation(ch)), "Expected the last name to have a special character");
    }

    [TestMethod]
    public void ShouldReturnSucessWhenNameIsValid() {
        var name = new Name("Ana", "Silva");

        Assert.IsTrue(name is not null, "Both first and last name are invalid");
    }
}