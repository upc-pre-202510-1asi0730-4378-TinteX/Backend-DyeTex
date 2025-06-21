using TinteX.DyeText.Platform.Profiles.Domain.Model.Commands;
using TinteX.DyeText.Platform.Profiles.Domain.Model.ValueObjects;

namespace TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;
public partial class Profile
{
    public int Id { get; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }

    public string FullName => Name.FullName;
    public string EmailAddress => Email.Address;

    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();
    }

    public Profile(string firstName, string lastName, string emailAddress)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(emailAddress);
    }

    public Profile(CreateProfileCommand command)
        : this(command.FirstName, command.LastName, command.Email) { }
}