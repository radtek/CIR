namespace Cir.Data.Access.Validation
{
    internal interface IValidation
    {
        string Name { get; }

        bool IsValid(dynamic cirSubmission, dynamic rule);
    }
}
