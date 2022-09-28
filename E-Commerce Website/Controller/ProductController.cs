using AutoMapper;
using E_Commerce_Website.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Website.Controller
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ProductController : ControllerBase
    {
        E_CommerceContext commerceContext;
        IMapper mapper;
        public ProductController(E_CommerceContext _context, IMapper _mapper)
        {
            commerceContext = _context;
            mapper = _mapper;

        }
        [HttpGet("SearchProduct")]
        public ActionResult Search(String s)
        {
            var product = commerceContext.Products.Find(s);
            if(product==null)
            {
                return BadRequest("invalid");
            }


            return Ok(product);
        }

        [HttpPost("Addproduct")]
        public ActionResult Add(AddProduct product )
        {

            Product p = mapper.Map<Product>(product);

            commerceContext.Products.Add(p);
            commerceContext.SaveChanges();

            return Ok(p);
        }

        [HttpPut("UpdateProduct")]
        public ActionResult UpdateProduct([FromQuery] int Id, [FromBody] AddProduct product )
        {
            var pro = commerceContext .Products .Find(Id);
            if (pro == null)
            {
                return BadRequest("invalid product");
            }

            Product pr = new Product
            {
                id = Id,
                name = product.name ?? pro.name,
                price = product.price ,
                quantity = product.quantity ,
                ImagePath=product.ImagePath ?? pro.ImagePath

            };

            commerceContext.Products.Update(pr);
            commerceContext.SaveChanges();

            return Ok("Done");
        }
        [HttpDelete("DeleteProduct")]
        public ActionResult DeleteProduct([FromBody] int Id)
        {
            var Product = commerceContext.Products.Find(Id);
            if (Product == null)
            {
                return BadRequest("There is no product with this id");
            }

            commerceContext.Products.Remove(Product);
            commerceContext.SaveChanges();

            return Ok("Done");
        }
        [HttpPost("AddImage")]
        public ActionResult AddImage(IFormFile file)
        {
            string fullPath = Directory.GetCurrentDirectory() + "/Images";

            string name = DateTime.Now.Ticks.ToString() + file.FileName;

            string filepath = fullPath + "/" + name;

            var stream = new FileStream(filepath, FileMode.Create);

            file.CopyTo(stream);

            return Ok(name);
        }

    }
}
