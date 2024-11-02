using bakkari.Models;
using bakkari.Repositories;
using Microsoft.JSInterop.Infrastructure;

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

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            IEnumerable<User> users = await _repository.GetUsersAsync();
            List<UserDTO> result = new List<UserDTO>();
            foreach (User user in users)
            {
                result.Add(UserToDTO(user));
            }
            return result;
        }

        public async Task<UserDTO> NewUserAsync(User user)
        {
            User? dbUser = await _repository.GetUserAsync(user.UserName);
            if (dbUser != null)
            {
                return null;
            }

            User? newUser = await _repository.NewUserAsync(user);
            if (newUser != null)
            {
                return UserToDTO(newUser);
            }
            return null;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            User? dbUser = await _repository.GetUserAsync(user.UserName);
            if (dbUser != null)
            {
                dbUser.FirstName = user.FirstName;
                dbUser.LastName = user.LastName;
                dbUser.Email = user.Email;
                dbUser.Password = user.Password;

                return await _repository.UpdateUserAsync(dbUser);
            }
            return false;
        }

        private UserDTO UserToDTO(User user)
        {
            UserDTO dto = new UserDTO();
            dto.UserName = user.UserName;
            dto.Email = user.Email;
            dto.FirstName = user.FirstName;
            dto.LastName = user.LastName;
            dto.JoinDate = user.JoinDate;
            dto.LastLogin = user.LastLogin;
            return dto;
        }
    }
}
