using bakkari.Models;
using bakkari.Repositories;

namespace bakkari.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> DeleteUserAsync(long id)
        {
            User? user = await _repository.GetUserAsync(id);
            if (user != null)
            {
                return await _repository.DeleteUserAsync(user);
            }
            return false;
        }

        public async Task<UserDTO> GetUserAsync(string username)
        {
            User? user = await _repository.GetUserAsync(username);
            if (user == null)
            {
                return null;
            }
            return UserToDTO(user);
        }

        public Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> NewUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
