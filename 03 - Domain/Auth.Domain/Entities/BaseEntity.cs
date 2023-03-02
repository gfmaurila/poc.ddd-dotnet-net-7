namespace Auth.Domain.Entities;
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime? Modified { get; set; }
    public bool Status { get; set; }

    internal List<string> _errors;
    public IReadOnlyCollection<string> Errors => _errors;

    public abstract bool Validate();
}