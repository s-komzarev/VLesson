using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class Service : IService
    {
        
            
        
        private EFApplicationDBContext dbContext;   //public static IList<Person> Persons { get; set; } = new List<Person>();
        public Service(EFApplicationDBContext eFApplicationDBContext)
        {
            dbContext = eFApplicationDBContext;
        }
        
        
        public IEnumerable<Person> GetPersonList()
        {
            return dbContext.Persons;
        }

        
        public Person GetById(int id)
        {


            return dbContext.Persons.Find(id);
            
            //foreach (var person in Persons)
            //{
            //    if (person.Id == id)
            //    {
            //        return person;
            //    }
            //}

            //return null;

        }

        
        public void Post(Person person)
        {

            dbContext.Persons.Add(person);
            dbContext.SaveChanges(); // ?
            
        }

        
        public string Put(int id, Person value)
        {


            //dbContext.Persons.Add(id, value)


            foreach (var person in dbContext.Persons) // (новая транзакция \ другие потоки) Есть несколько идей как это реализовать : using \ toList()\toArray() → потеря памяти.
            {
                if (person.Id == id) // можно сделать через "!="
                {
                    
                    person.FirstName = value.FirstName;
                    break; // добавил чтобы выйти из цикла минуя (return "Not updated") и сохранить изменения (чувствую - не самый изящный способ)
                           //return "Updated"; → перенес, чтобы продолжить выполнение

                }
                return "Not updated";
                
            }
            dbContext.SaveChanges();  // Нельзя поместить в теле цикла "foreach"
            return "Updated";
        }

        
        public void Delete(int id)
        {

            Person p = new();

            foreach (Person person in dbContext.Persons)
            {
                if (person.Id == id)
                {
                    p = person;
                }

            }
            if (p != null)
            {
                dbContext.Persons.Remove(p);
                dbContext.SaveChanges(); // ?
            }
            else Console.WriteLine("bad operation"); 
                
        }



    }
}
