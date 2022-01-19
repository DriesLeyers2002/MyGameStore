using MyGameStore.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameStore.Data.UOW
{
    public interface IUnitOfWork
    {
        public int Commit();
        public IPersonRepositorie PersonRepositorie { get; }
        public IStoreRepositorie StoreRepositorie { get; }
    }
}
