using ContactsWebAPI.Models;
using ContactsWebAPI.Services.ContactService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        public readonly IContactService _service;

        public ContactController(IContactService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            var contacts = await _service.GetAllContacts();
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<ActionResult<List<Contact>>> AddContact(Contact contact)
        {
            var contacts = await _service.AddContact(contact);
            return Ok(contacts);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Contact>>> DeleteContact(int id)
        {
            var contacts = await _service.DeleteContact(id);
            if(contacts == null)
            {
                return NotFound("Contact not found in the Database");
            } else
            {
                return Ok(contacts);
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<Contact>>> UpdateContact(Contact contact)
        {
            var contacts = await _service.UpdateContact(contact);

            if(contacts == null)
            {
                return NotFound("Contact not found in the Database");
            } else
            {
                return Ok(contacts);
            }
        }
    }
}
