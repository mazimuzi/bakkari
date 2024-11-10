using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using bakkari.Models;
using bakkari.Repositories;

namespace bakkari.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessageServiceContext _context;
        public MessageRepository(MessageServiceContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteMessageAsync(Message message)
        {
            if (message == null) { return false; }
            else
            {
                _context.Messages.Remove(message);
                await _context.SaveChangesAsync();
                return true;
            }
        }


        public async Task<IEnumerable<Message>> GeMyReceivedMessagesAsync(User user)
        {
            //range tms

            return await _context.Messages.Include(s => s.Sender).Where(x => x.Recipient == null).OrderByDescending(x => x.Id).Take(5).ToListAsync();
        }

        public async Task<Message?> GetMessageAsync(long id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task<IEnumerable<Message>> GetMessagesAsync()
        {
            return await _context.Messages.Include(s => s.Sender).Where(x => x.Recipient == null).OrderByDescending(x => x.Id).Take(10).ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetMessagesAsync(long id)
        {
            return await _context.Messages.Include(s => s.Sender).Where(x => x.Recipient == null).OrderByDescending(x => x.Id).Take(15).ToListAsync();
        }


        public async Task<IEnumerable<Message>> GetMySentMessagesAsync(User user)
        {
            return await _context.Messages.Include(s => s.Sender).Where(x => x.Recipient == null).OrderByDescending(x => x.Id).Take(5).ToListAsync();
        }

        public async Task<Message?> NewMessageAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<bool> UpdateMessageAsync(Message message)
        {
            _context.Entry(message).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
