using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGameStore.Context;
using MyGameStore.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyGameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private MyGameStoreContext _context;

        public PeopleController(MyGameStoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if(_context.Stores.FirstOrDefault(x => x.Id == person.StoreId) is not null)
            {
                _context.People.Add(person);
                _context.SaveChanges();
                return Created("https://localhost:44317/api/People/", person);
            }

            return NotFound();
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.People);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult Update([FromBody] Person person, int id)
        {
            if (id == person.Id)
            {
                if (_context.People.FirstOrDefault(x => x.Id == person.Id) is not null)
                {
                    _context.Update(person);
                    _context.SaveChanges();

                    return Ok();
                }
            }

            return NotFound();
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Person person = new() { Id = id };
            
            if(person is not null)
            {
                _context.Remove(person);
                _context.SaveChanges();

                return Ok();
            }

            return NotFound();
        }
    }
}
