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
    public class SaleController : Controller
    {
        SaleService CreateService()
        {
            SaleContext db = new SaleContext();
            ProductRepository productRepository = new ProductRepository(db);
            SaleRepository saleRepository = new SaleRepository(db);
            SaleDetailRepository saleDetailRepository = new SaleDetailRepository(db);
            SaleService service = new SaleService(saleRepository, productRepository, saleDetailRepository);
            return service;
        }
        // GET: api/values
        [HttpGet]
        public ActionResult<List<Sale>> Get()
        {
            var service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Sale> Get(Guid id)
        {
            var service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Sale> Post([FromBody]Sale sale)
        {
            var service = CreateService();
            return Ok(service.Add(sale));
        }


        // DELETE api/values/5
        [HttpDelete("{id}/cancel")]
        public ActionResult Cancel(Guid id)
        {
            var service = CreateService();
            service.Cancel(id);
            return Ok("Sale was canceled...");
        }
    }
}

