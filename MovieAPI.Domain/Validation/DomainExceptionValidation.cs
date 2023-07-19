namespace MovieAPI.Domain.Validation;

public class DomainExceptionValidation : Exception
{
    public DomainExceptionValidation(string error) : base(error)
    {
        
    }

    public static void HasError(bool HasError, string error) {
        if(HasError) throw new DomainExceptionValidation(error);
    }
}