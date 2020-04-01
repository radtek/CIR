namespace Cir.Data.Access.Validation
{
    public interface IValidation
    {
        bool IsValid(params string[] parameters);
    }
}
