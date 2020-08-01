using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SearchFill.Data;
using SearchFill.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SearchFill.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryListController : ControllerBase
    {
        private readonly SearchFillContext _context;

        public CountryListController(SearchFillContext context)
        {
            _context = context;
        }

        //BOOTSTRAP
        // GET: api/<CountryListController>
        [HttpGet]
        public async Task<IEnumerable<CountryDTO>> Get()
        {
            string term = HttpContext.Request.Query["q"].ToString();
            var countries = await _context.Country.Where(c => c.Name.Contains(term)).ToListAsync();
            var countryListDTO = new List<CountryDTO>();
            foreach (Country c in countries)
            {
                countryListDTO.Add(new CountryDTO { value = c.Id, text = c.Name });
            }

            return countryListDTO;
        }

        //JQUERY
        //[HttpGet]
        //public IEnumerable<CountryListDTO> Get()
        //{
        //    string term = HttpContext.Request.Query["term"].ToString();
        //    var countries = _context.Country.Where(c => c.Name.Contains(term)).ToList();
        //    var countryListDTO = new List<CountryListDTO>();
        //    foreach (Country c in countries)
        //    {
        //        countryListDTO.Add(new CountryListDTO { value = c.Id, label = c.Name });
        //    }

        //    return countryListDTO;
        //}


        // GET api/<CountryListController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountryListController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountryListController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountryListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
