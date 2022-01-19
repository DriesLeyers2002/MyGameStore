using MyGameStore.Data.Context;
using MyGameStore.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameStore.Data.Repositories
{
    public class StoreRepositorie : IStoreRepositorie
    {
        private MyGameStoreContext _context;

        public StoreRepositorie(MyGameStoreContext context)
        {
            _context = context;
        }
     
        public void Delete(int id)
        {
            Store store = new() { Id = id };

            if (store is not null)
            {
                _context.Remove(store);
            }
            else
            {
                throw new Exception();
            }
        }

        public List<Store> Get()
        {
            return _context.Stores.ToList();
        }

        public void Post(Store store)
        {
            if (_context.Stores.First(x => x.Name == store.Name) is null)
            {
                _context.Stores.Add(store);
            }
            else {
                throw new Exception();
            }
        }

        public void Update(Store store)
        {
            if (_context.Stores.First(x => x.Id == store.Id) is not null)
            {
                if (_context.Stores.First(x => x.Name == store.Name) is null)
                {
                    _context.Update(store);
                }
                throw new Exception();
            }

            throw new Exception();
        }
    }
}
