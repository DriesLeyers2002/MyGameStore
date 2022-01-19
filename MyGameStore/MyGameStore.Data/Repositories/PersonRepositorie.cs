using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGameStore.Data.Context;
using MyGameStore.Data.Model;

namespace MyGameStore.Data.Repositories
{
    public class PersonRepositorie : IPersonRepositorie
    {
        
        private MyGameStoreContext _context;

        public PersonRepositorie(MyGameStoreContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            Person person = new() { Id = id };

            if (person is not null)
            {
                _context.Remove(person);
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
            }
        }
    }
}
