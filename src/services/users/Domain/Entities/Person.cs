namespace UsersApi.Domain.Entities;

public enum Gender { Male, Female }

public class Person
{
    private Person() { }
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public Gender Gender { get; private set; }
    public int? LocationId { get; private set; }
    public string? Location { get; private set; }
}