using MyGameStore.Data.Context;
using MyGameStore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameStore.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private MyGameStoreContext _context;
        private IStoreRepositorie _storeRepositorie;
        private IPersonRepositorie _personRepositorie;

        public UnitOfWork(MyGameStoreContext myGameStoreContext, IStoreRepositorie storeRepositorie, IPersonRepositorie personRepositorie)
        {
            _context = myGameStoreContext;
            _storeRepositorie = storeRepositorie;
            _personRepositorie = personRepositorie;
        }

        public IStoreRepositorie StoreRepositorie { get { return _storeRepositorie; } }
        public IPersonRepositorie PersonRepositorie { get { return _personRepositorie; } }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
