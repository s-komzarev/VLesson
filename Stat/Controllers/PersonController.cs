using Microsoft.AspNetCore.Mvc;
using Models;
using Services;



namespace Stat.Controllers
{
    
    
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase // И тут этот Base о котором мы достаточно мало знаем :)
    {


        public IService _service;

        public PersonController(IService service)
        {

            _service = service;
        }


        [HttpGet]
        public IEnumerable<Person> Get()
        {
                 
            return _service.GetPersonList();

        }

        
        
        [HttpGet("{id}")]
        public Person GetById(int id)
        {                    
            
            return _service.GetById(id);

        }

        
        
        [HttpPost]
        public void Post([FromBody] Person person) 
        {
            
            _service.Post(person);

        }
                
        
        
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Person value)
        {
            
            return _service.Put(id, value);

        }

                    
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
            _service.Delete(id);
            
        }


    }
}
