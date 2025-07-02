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
        
            public string Phone { get; private set; } = string.Empty;
            public bool MembershipActive { get; private set; } = false;
            public string Theme { get; private set; } = "light";
            
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
                : this(command.FirstName, command.LastName, command.Email)
            {
                Phone = command.Phone;
                MembershipActive = command.MembershipActive;
                Theme = command.Theme;
            }
            
            public void Update(string firstName, string lastName, string email, string phone, bool membershipActive, string theme)
            {
                Name = new PersonName(firstName, lastName);
                Email = new EmailAddress(email);
                Phone = phone;
                MembershipActive = membershipActive;
                Theme = theme;
            }
            public void SetMembership(bool active) => MembershipActive = active;
            public void SetTheme(string theme) => Theme = theme;
        }