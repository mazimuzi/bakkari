using bakkari.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using bakkari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using bakkari.Middleware;


namespace bakkari.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IUserAuthenticationService _userAuthenticationService;

        public MessagesController(IMessageService service, IUserAuthenticationService authentication)
        {
            _messageService = service;
            _userAuthenticationService = authentication;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageDTO>>> GetMessages()
        {
            return Ok(await _messageService.GetMessagesAsync());
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDTO>> GetMessage(long id)
        {
            MessageDTO? message = await _messageService.GetMessageAsync(id);

            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }



        [HttpPut("{id}")]

        public async Task<IActionResult> PutMessage(long id, MessageDTO message)
        {
            if (id != message.Id)
            {
                return BadRequest();
            }

            bool result = await _messageService.UpdateMessageAsync(message);

            if ((!result))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]

        public async Task<ActionResult<MessageDTO>> PostMessage(MessageDTO message)
        {
            MessageDTO? newMessage = await _messageService.NewMessageAsync(message);
            if (newMessage == null)
            {
                return Problem();
            }
            return CreatedAtAction("GetMessage", new { id = message.Id }, message);
        }

        [HttpDelete("{id}")]
        [Authorize]

        public async Task<IActionResult> DeleteMessage(long id)
        {
            string username = this.User.FindFirst(ClaimTypes.Name).Value;
            if (!await _userAuthenticationService.isMyMessage(username, id))
            {
                return BadRequest();
            }
            bool result = await _messageService.DeleteMessageAsync(id);
            if ((!result))
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
