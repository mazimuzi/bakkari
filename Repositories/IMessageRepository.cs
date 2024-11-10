using bakkari.Models;

namespace bakkari.Repositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetMessagesAsync();
        Task<IEnumerable<Message>> GetMySentMessagesAsync(User user);
        Task<IEnumerable<Message>> GeMyReceivedMessagesAsync(User user);
        Task<IEnumerable<Message>> GetMessagesAsync(long id);
        Task<Message?> GetMessageAsync(long id);
        Task<Message?> NewMessageAsync(Message message);
        Task<bool> UpdateMessageAsync(Message message);
        Task<bool> DeleteMessageAsync(Message message);
    }
}
