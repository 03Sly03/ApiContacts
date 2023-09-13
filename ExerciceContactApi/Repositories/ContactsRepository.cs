using ExerciceContactApi.Data;
using ExerciceContactApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciceContactApi.Repositories
{
    public class ContactsRepository : IRepository<Contact>
    {
        private readonly ApplicationDbContext _context;

        public ContactsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Post(Contact contact)
        {
            var addedObj = _context.Contacts.Add(contact);
            _context.SaveChanges();
            return addedObj.Entity.Id > 0;
        }

        public List<Contact> Get()
        {
            return _context.Contacts.ToList();
        }

        public Contact? GetById(int id)
        {
            return _context.Contacts.Find(id);
        }

        public List<Contact> GetByFirstname(string str)
        {
            var contacts = _context.Contacts.Where(contact => contact.Firstname!.StartsWith(str)).ToList();
            return contacts;
        }

        public bool Put(Contact contact)
        {
            var updatedObj = _context.Contacts.Update(contact);
            _context.SaveChanges();
            return updatedObj.Entity.Id > 0;
        }

        public bool Delete(int id)
        {
            var contactToDelete = _context.Contacts.Find(id);
            if (contactToDelete == null)
                return false;
            _context.Contacts.Remove(contactToDelete);
            return _context.SaveChanges() > 0;
        }
    }
}
