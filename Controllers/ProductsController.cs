using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Products> products = new List<Products> {
        new Products {Id=1, Name="p1" , Description="aaa"} ,
         new Products {Id=2, Name="p2" , Description="aaa"}


        };

        ///////////////////GetAll///////////////////////////
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        ///////////////////GetAll///////////////////////////


        ///////////////////GetByID///////////////////////////
        [HttpGet(template: "{id}")]
        public IActionResult GetByID(int id)
        {
            var product = products.First(s => s.Id == id);
            if (product == null) {  return NotFound(); }  
            return Ok(product);
        }

        ///////////////////GetByID///////////////////////////


        ///////////////////Add///////////////////////////
        [HttpPost]
        public IActionResult add(Products req)
        {
            if (req == null)
            {
                return BadRequest();
            }

            var product = new Products
            {
                Id = req.Id,
                Name = req.Name,
                Description = req.Description,
            };
            products.Add(product);
            return Ok(product);
        }
        ///////////////////Add///////////////////////////


        ///////////////////Update///////////////////////////
        [HttpPut("{id}")]
         public IActionResult Update(int id, Products req)
        {
            var productt = products.FirstOrDefault(s => s.Id == id);
            if (productt is null)  return NotFound(); 
            productt.Name = req.Name;
            productt.Description = req.Description;
            return Ok(productt);
        }
        ///////////////////Update///////////////////////////



        ///////////////////Delete///////////////////////////
        [HttpDelete("{id}")]
        public IActionResult Delete(int id )
        {
             
            var product = products.First(s => s.Id == id);
            if (product == null) { return NotFound(); }
            products.Remove(product);
         
            return Ok();
        }
        ///////////////////Delete///////////////////////////
    }
}
