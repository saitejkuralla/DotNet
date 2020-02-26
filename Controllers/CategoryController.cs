using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Domains;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // GET: api/Category
        [HttpGet]
        public List<Category> Get()
        {
            var Categories = new List<Category>()
           {
             new Category  {CategoryDescription="BLACK FRIDAY DEAL",Image="https://placehold.it/150x80?text=IMAGE",CategoryId=1,CategoryName="Grocery"},
            new Category {CategoryDescription="BLACK FRIDAY DEAL",Image="https://placehold.it/150x80?text=IMAGE",CategoryId=2,CategoryName="Daily Needs"},
            new Category  {CategoryDescription="BLACK FRIDAY DEAL",Image="https://placehold.it/150x80?text=IMAGE",CategoryId=3,CategoryName="Fresh Fruits"},
            new Category {CategoryDescription="BLACK FRIDAY DEAL",Image="https://placehold.it/150x80?text=IMAGE",CategoryId=4,CategoryName="Milk"}
           };

            return Categories;
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Category
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
