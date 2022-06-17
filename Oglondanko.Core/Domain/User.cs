namespace Oglondanko.Core.Domain
{
    public class User : Entity
    {
        public string Role {get; protected set;}
        public string Name {get; protected set;}
        public string Email {get; protected set;}
        public string Password {get; protected set;}
        public DateTime CreatedAt {get; protected set;}

        protected User()
        {
            
        }

        public User(Guid id, string role, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Role = role;
            Email = email;
            Password = password;
            CreatedAt = DateTime.UtcNow;
        }

    }
}