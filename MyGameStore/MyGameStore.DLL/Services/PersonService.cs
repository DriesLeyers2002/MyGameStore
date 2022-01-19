using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGameStore.Data.Context;
using MyGameStore.Data.Model;
using MyGameStore.DLL.Interfaces;

namespace MyGameStore.DLL.Services
{
    public class PersonService : IPersonService
    {
        private MyGameStoreContext _context;

        public PersonService(MyGameStoreContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            Person person = new() { Id = id };

            if (person is not null)
            {
                _context.Remove(person);
                _context.SaveChanges();
            }
        }

        public List<Person> Get()
        {
            return _context.People.ToList();
        }

        public void Post(Person person)
        {
            if (_context.Stores.FirstOrDefault(x => x.Id == person.StoreId) is not null)
            {
                _context.People.Add(person);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }

        public void Update(Person person)
        {
            if (_context.People.FirstOrDefault(x => x.Id == person.Id) is not null)
            {
                _context.Update(person);
                _context.SaveChanges();
            }
        }
    }
}
