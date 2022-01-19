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
    public class StoreController : ControllerBase
    {
        private MyGameStoreContext _context;
        public enum sortBy
        {
            NameAscending,
            NameDescending,
            ZipCodeAscending,
            ZipCodeDescending
        }

        public StoreController(MyGameStoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Store store)
        {
            if(_context.Stores.First(x => x.Name == store.Name) is null)
            {
                _context.Stores.Add(store);
                _context.SaveChanges();
                return Created("https://localhost:44317/api/Store/", store);
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult Get([FromQuery] sortBy sort,[FromHeader] string city = "", [FromHeader] string zipCode = "", [FromHeader] int page = 1, [FromHeader] int pageLength = 10)
        {
            List<Store> stores = _context.Stores.ToList();

            if (city != "")
            {
                stores = stores.Where(x => x.City == city).ToList();
                return Ok(stores);
            } else if (zipCode != "")
            {
                stores = stores.Where(x => x.Zipcode == zipCode).ToList();
                return Ok(stores);
            }

            if (sort == sortBy.ZipCodeAscending)
            {
                stores = stores.OrderBy(x => Int32.Parse(x.Zipcode)).ToList();
            }
            else if (sort == sortBy.ZipCodeDescending)
            {
                stores = stores.OrderByDescending(x => Int32.Parse(x.Zipcode)).ToList();
            }
            else if (sort == sortBy.NameAscending)
            {
                stores = stores.OrderByDescending(x => x.Name).ToList();
            }
            else if (sort == sortBy.NameDescending)
            {
                stores = stores.OrderByDescending(x => x.Name).ToList();
            }

            stores = stores.Skip((page - 1) * pageLength).ToList();
            stores = stores.Take(pageLength).ToList();
            return Ok(stores);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Store store)
        {
            if (_context.Stores.First(x => x.Id == store.Id) is not null)
            {
                if (_context.Stores.First(x => x.Name == store.Name) is null)
                {
                    _context.Update(store);
                    _context.SaveChanges();
                    return Ok();
                }

                return NotFound();
            }

            return NotFound();
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Store store = new() { Id = id };

            if (store is not null)
            {
                _context.Remove(store);
                _context.SaveChanges();

                return Ok();
            }

            return NotFound();

        }

        [Route("{id}/people")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            List<Person> people = new List<Person>();
            Store store = _context.Stores.First(x => x.Id == id);
            people = _context.People.ToList();
            people = people.Where(x => x.Store.Id == id).ToList();
            return Ok(people);
        }
    }
}
