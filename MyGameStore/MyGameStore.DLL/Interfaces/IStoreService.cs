using MyGameStore.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameStore.DLL.Interfaces
{
    public interface IStoreService
    {
        public List<Store> Get();
        public void Post(Store store);
        public void Update(Store store);
        public void Delete(int id);
    }
}
