using bakkari.Models;

namespace bakkari.Repositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetMessagesAsync();
        Task<Message?> GetMessageAsync(long id);
        Task<Message> NewMessageAsync(Message message);
        Task<bool> UpdateMessageAsync(Message message);
        Task<bool> DeleteMessageAsync(Message message);
    }
}
