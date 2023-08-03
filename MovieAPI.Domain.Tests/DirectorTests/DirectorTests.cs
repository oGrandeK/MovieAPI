using MovieAPI.Domain.Entities;
using MovieAPI.Domain.Validation;
using MovieAPI.Domain.ValueObjects;

namespace MovieAPI.Domain.Tests.DirectorTests;

[TestClass]
public class DirectorTests
{
    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenDirectorNameIsNull() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var director = new Director(null);
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenDirectorFirstNameIsNull() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var director = new Director(new Name(null, "Silva"));
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenDirectorLastNameIsNull() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var director = new Director(new Name("Carlos", null));
        });
    }
    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenDirectorFirstNameContainsDigit() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var director = new Director(new Name("C4rl0s", "Silva"));
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenDirectorLastNameContainsDigit() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var director = new Director(new Name("Carlos", "S1lv4"));
        });
    }
    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenDirectorFirstNameIsSpecialCharacter() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        { 
            var director = new Director(new Name("C@rlos", "Silva"));
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenDirectorLasNameIsSpecialCharacter() {
        Assert.ThrowsException<DomainExceptionValidation>(() =>
        {
            var director = new Director(new Name("Carlos", "S!lva"));
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenDirectorFirstNameHasLessThan3Characters() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var director = new Director(new Name("Ca", "Silva"));
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenDirectorLastNameHasLessThan3Characters() {
        Assert.ThrowsException<DomainExceptionValidation>(() =>
        {
            var director = new Director(new Name("Carlos", "Si"));
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenDirectorFirstNameHas31orMoreCharactersLong() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var director = new Director(new Name("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Silva"));
        });
    }

    [TestMethod]
    public void ShouldReturnDomainExceptionValidationWhenDirectorLastNameHas31orMoreCharactersLong() {
        Assert.ThrowsException<DomainExceptionValidation>(() => 
        {
            var director = new Director(new Name("Carlos", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
        });
    }
}