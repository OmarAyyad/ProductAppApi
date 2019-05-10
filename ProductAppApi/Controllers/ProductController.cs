using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using ProductAppApi.Core.Domain;
using ProductAppApi.Persistance;

namespace ProductAppApi.Controllers
{
    /// <summary>
    /// This is the Api Controller 
    /// that includes the get , get by id , post , put and delete
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private UnitOfWork uni;
        /// <summary>
        /// This is the product constructor 
        /// that we can inject the context and instantiate our unit of work 
        /// </summary>
        /// <param name="productContext"></param>
        public ProductController(ProductContext productContext)
        {
            uni = new UnitOfWork(productContext);
        }

        /// <summary>
        /// this is the get all JsonResult 
        /// that inherits from actionresult class that would return all the listing data
        /// </summary>
        /// <returns></returns>
        // GET api/Product
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(uni.Products.GetAll().ToList());
        }


        /// <summary>
        /// this is the get by id jsonresult
        /// that would take the id and search for it through the find method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/Product/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Product pro = uni.Products.Find(p => p.Id == id).SingleOrDefault();
            if (pro == null)
            {
                return NotFound(JsonConvert.SerializeObject(new { id = new string[]{string.Format("The value '{0}' is not found.",id )} }));
            }
            return new JsonResult(uni.Products.Find(p => p.Id == id).SingleOrDefault());
        }




        /// <summary>
        /// this is our post method
        /// that takes an entity (which is Product) and add it to the DataBase
        /// </summary>
        /// <param name="product"></param>

        // POST api/Product
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            if (product.Id == 0)
            {

                uni.Products.Add(product);
                int rowaff = uni.complete();
                if (rowaff > 0)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(JsonConvert.SerializeObject(new { ErrorMessage = "No product was added" }));
                }
            }
            else
            {
                return BadRequest(JsonConvert.SerializeObject(new { ErrorMessage = "Please Don't include the id with the product as it's generated" }));
            }
        }

        /// <summary>
        /// this is the put method 
        /// that is used to update a certain entity using it's id and the modefied object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        // PUT api/Product/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            if (uni.Products.Get(id) != null && id != 0)
            {
                uni.Products.Update(uni.Products.MapProduct(id, product));
                uni.complete();
                return Ok();
            }
            else
            {
                ModelStateDictionary keys = new ModelStateDictionary();
                return NotFound(JsonConvert.SerializeObject(new { id = new string[]{string.Format("The value '{0}' is not found.",id )} }));
            }
        }

        /// <summary>
        /// this is the delete method 
        /// that takes the id and removes the entity from Database
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/Product/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (uni.Products.Get(id) != null)
            {
                uni.Products.Remove(id);
                uni.complete();
                return Ok();
            }
            else
            {
                return NotFound(JsonConvert.SerializeObject(new { id = new string[]{string.Format("The value '{0}' is not found.",id )} }));
            }

        }
    }
}
