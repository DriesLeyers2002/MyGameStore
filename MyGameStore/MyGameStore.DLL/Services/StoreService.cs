using MyGameStore.Data.Context;
using MyGameStore.Data.Model;
using MyGameStore.Data.UOW;
using MyGameStore.DLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameStore.DLL.Services
{
    public class StoreService : IStoreService
    {
        private IUnitOfWork _unitOfWork;

        public StoreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            _unitOfWork.StoreRepositorie.Delete(id);
            _unitOfWork.Commit();
        }

        public List<Store> Get()
        {
            return _unitOfWork.StoreRepositorie.Get();
        }

        public void Post(Store store)
        {
            _unitOfWork.StoreRepositorie.Post(store);
            _unitOfWork.Commit();
        }

        public void Update(Store store)
        {
            _unitOfWork.StoreRepositorie.Update(store);
            _unitOfWork.Commit();
        }
    }
}
