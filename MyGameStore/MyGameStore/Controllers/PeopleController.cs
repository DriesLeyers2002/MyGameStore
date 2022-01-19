using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGameStore.Data.Model;
using MyGameStore.DLL.Interfaces;
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
        private IPersonService personService;

        public PeopleController(IPersonService context)
        {
            personService = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            try
            {
                personService.Post(person);
                return Created("https://localhost:44317/api/People/", person);
            }
            catch(Exception e)
            {
                return NotFound();
            }

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(personService.Get());
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult Update([FromBody] Person person, int id)
        {
            if (id == person.Id)
            {
                personService.Update(person);

                return Ok();
            }

            return NotFound();
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            personService.Delete(id);

            return NotFound();
        }
    }
}
