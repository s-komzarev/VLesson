using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IService
    {
        IEnumerable<Person> GetPersonList();
       
        public Person GetById(int id);
        
        public void Post(Person person);
        
        public string Put(int id, Person value);
        
        public void Delete(int id);

    }
}
