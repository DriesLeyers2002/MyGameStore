using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGameStore.Data.Context;
using MyGameStore.Data.Model;
using MyGameStore.Data.UOW;
using MyGameStore.DLL.Interfaces;

namespace MyGameStore.DLL.Services
{
    public class PersonService : IPersonService
    {
        private IUnitOfWork _unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            _unitOfWork.PersonRepositorie.Delete(id);
            _unitOfWork.Commit();
        }

        public List<Person> Get()
        {
            return _unitOfWork.PersonRepositorie.Get();
        }

        public void Post(Person person)
        {
            _unitOfWork.PersonRepositorie.Post(person);
            _unitOfWork.Commit();
        }

        public void Update(Person person)
        {
            _unitOfWork.PersonRepositorie.Update(person);
            _unitOfWork.Commit();
        }
    }
}
