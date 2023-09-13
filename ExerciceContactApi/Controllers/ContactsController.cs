using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExerciceContactApi.Data;
using ExerciceContactApi.Models;
using ExerciceContactApi.Repositories;
using ExerciceContactApi.DTO;

namespace ExerciceContactApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IRepository<Contact> _contactRepository;

        public ContactsController(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET: api/Contacts
        [HttpGet]
        public IActionResult GetContacts()
        {
              var contacts = _contactRepository.Get();
              if (contacts == null)
              {
                  return NoContent();
              }
              return Ok(contacts);
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var contact = _contactRepository.GetById(id);

            if (contact == null)
            {
                return NoContent();
            }

            return Ok(contact);
        }

        // GET: api/Contacts/Firstname/{str}
        [HttpGet("Firstname/{str}")]
        public IActionResult GetContactsFirstnameStartWith(string str)
        {
            var contacts = _contactRepository.GetByFirstname(str);
            if (!contacts!.Any())
                return NoContent();
            return Ok(contacts);
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutContact(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            if (_contactRepository.Put(contact))
                return Ok(contact);
            return NotFound();
        }

        [HttpPost]
        public IActionResult PostContactDto(CreateContactRequest createContact)
        {
            var contact = new Contact()
            {
                Lastname = createContact.Lastname,
                Firstname = createContact.Firstname,
                Fullname = createContact.Fullname,
                Birthdate = createContact.Birthdate,
                Sexe = createContact.Sexe,
                Avatar = createContact.Avatar
            };

            if (!_contactRepository.Post(contact))
            {
                return Problem("Error Contact not Added");
            }

            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            if (_contactRepository.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}
