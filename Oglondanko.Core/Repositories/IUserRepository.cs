using Oglondanko.Core.Domain;

namespace Oglondanko.Core.Repositories
{
    public interface IUserRepository
    {
         Task<User> GetAsync(Guid id);
         Task<User> GetAsync(String email);
         Task AddAsync(User user);
         Task UpdateAsync(User user);
         Task DeleteAsync(User user);
         
    }
}