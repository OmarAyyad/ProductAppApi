using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductAppApi.Core.Domain;
using ProductAppApi.Persistance;

namespace ProductAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private UnitOfWork uni;

        public ProductController(ProductContext productContext)
        {
            uni = new UnitOfWork(productContext);
        }

        // GET api/Product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return uni.Products.GetAll().ToList();
        }

        // GET api/Product/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return uni.Products.Find(p => p.Id == id).SingleOrDefault();
        }

        // POST api/Product
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            uni.Products.Add(product);
            uni.complete();
        }

        // PUT api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            product.Id=id;
            uni.Products.Update(product);
            uni.complete();
        }

        // DELETE api/Product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            uni.Products.Remove(id);
            uni.complete();

        }
    }
}
