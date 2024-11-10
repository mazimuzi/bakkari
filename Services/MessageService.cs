using bakkari.Models;
using bakkari.Repositories;
using bakkari.Services;
using System.Drawing.Text;

namespace bakkari.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repository;
        private readonly IUserRepository _userRepository;
        public MessageService(IMessageRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<bool> DeleteMessageAsync(long id)
        {
            Message? message = await _repository.GetMessageAsync(id);
            if (message != null)
            {
                await _repository.DeleteMessageAsync(message);
                return true;
            }
            return false;
        }

        public async Task<MessageDTO?> GetMessageAsync(long id)
        {
            return MessageToDTO(await _repository.GetMessageAsync(id));
        }
        private async Task<Message> DTOToMessageAsync(MessageDTO dTO)
        {
            Message newMessage = new Message();
            newMessage.Id = dTO.Id;
            newMessage.Title = dTO.Title;
            newMessage.Body = dTO.Body;



            User? sender = await _userRepository.GetUserAsync(dTO.Sender);
            if (sender != null)
            {
                newMessage.Sender = sender;
            }
            if (dTO.Recipient != null)
            {
                User? recipient = await _userRepository.GetUserAsync(dTO.Recipient);
                if (recipient != null)
                {
                    newMessage.Recipient = recipient;
                }
            }
            return newMessage;
        }
        private MessageDTO MessageToDTO(Message message)
        {
            MessageDTO dTO = new MessageDTO();
            dTO.Id = message.Id;
            dTO.Title = message.Title;
            dTO.Body = message.Body;
            dTO.Sender = message.Sender.UserName;
            if (message.Recipient != null)
            {
                dTO.Recipient = message.Recipient.UserName;
            }
            if (message.PrevMessage != null)
            {
                dTO.PrevMessage = message.PrevMessage.Id;
            }
            return dTO;
        }


        public Task<IEnumerable<MessageDTO>> GetMessagesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MessageDTO> NewMessageAsync(MessageDTO message)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMessageAsync(MessageDTO message)
        {
            throw new NotImplementedException();
        }
    }
}
