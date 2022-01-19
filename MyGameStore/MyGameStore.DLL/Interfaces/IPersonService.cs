using MyGameStore.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameStore.DLL.Interfaces
{
    public interface IPersonService
    {
        public List<Person> Get();
        public void Post(Person person);
        public void Update(Person person);
        public void Delete(int id);
    }
}
