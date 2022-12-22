using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesApp.Domain;
using SalesApp.Aplication.Services;
using SalesApp.Infrastructure.Data.Context;
using SalesApp.Infrastructure.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesApp.Infrastructure.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        ProductService CreateService()
        {
            SaleContext db = new SaleContext();
            ProductRepository repository = new ProductRepository(db);
            ProductService service = new ProductService(repository);
            return service;
        }
        // GET: api/values
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            var service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(Guid id)
        {
            var service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            var service = CreateService();            
            return Ok(service.Add(product));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

