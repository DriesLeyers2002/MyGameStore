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
    public class StoreController : ControllerBase
    {
        private IStoreService storeService;
        private IPersonService personService;

        public enum sortBy
        {
            NameAscending,
            NameDescending,
            ZipCodeAscending,
            ZipCodeDescending
        }

        public StoreController(IStoreService context, IPersonService service)
        {
            storeService = context;
            personService = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Store store)
        {
            try
            {
                storeService.Post(store);
                return Created("https://localhost:44317/api/Store/", store);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Get([FromQuery] sortBy sort, [FromHeader] string city = "", [FromHeader] string zipCode = "", [FromHeader] int page = 1, [FromHeader] int pageLength = 10)
        {
            List<Store> stores = storeService.Get();

            if (city != "")
            {
                stores = stores.Where(x => x.City == city).ToList();
                return Ok(stores);
            }
            else if (zipCode != "")
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
            try
            {
                storeService.Update(store);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                storeService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }

        [Route("{id}/people")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            List<Person> people = new List<Person>();
            Store store = storeService.Get().First(x => x.Id == id);
            people = personService.Get();
            people = people.Where(x => x.Store.Id == id).ToList();
            return Ok(people);
        }
    }
}
