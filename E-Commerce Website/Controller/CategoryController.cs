using AutoMapper;
using E_Commerce_Website.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Website.Controller
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CategoryController : ControllerBase
    {
        E_CommerceContext commercecontext;
        IMapper mapper;
        public CategoryController(E_CommerceContext _context , IMapper _mapper)
        {
            commercecontext = _context;
            mapper = _mapper;
        }

        [HttpGet("GetCategory")]
        public ActionResult getcategory()
        {
            var lst = commercecontext.Categories.ToList();

            return Ok(lst);
        }
        [HttpGet("SearchCategory")]
        public ActionResult Search(int s)
        {
            var category = commercecontext.Categories.Find(s);
            if (category == null)
            {
                return BadRequest("invalid");
            }


            return Ok(category);
        }


        [HttpPost("AddCategory")]
        public ActionResult Add(AddCategory category)
        {

            //Category c = mapper.Map<Category>(category);
            Category c = new Category
            {
                name = category.name,
                ImagePath = category.ImagePath
            };

            commercecontext.Categories.Add(c);
            commercecontext.SaveChanges();

            return Ok(c);
        }


        [HttpPut("UpdateCategory")]
        public ActionResult UpdateCategory([FromQuery] int Id, [FromBody] AddCategory category)
        {
            var cat = commercecontext.Categories.Find(Id);
            if (cat == null)
            {
                return BadRequest("invalid category");
            }

            Category ct = new Category
            {
                id = Id,
                name = category.name ?? cat.name,
                ImagePath = category.ImagePath ?? cat.ImagePath

            };

            commercecontext.Categories.Update(ct);
            commercecontext.SaveChanges();

            return Ok("Done");
        }


        [HttpDelete("DeleteCategory")]
        public ActionResult DeleteCategory([FromBody] int Id)
        {
            var listofproducts = commercecontext.Products.Where(x => x.categoryid == Id).ToList();

            foreach (var item in listofproducts)
            {
                commercecontext.Products.Remove(item);    
            }
            commercecontext.SaveChanges();

            var category = commercecontext.Categories.Find(Id);
            if (category == null)
            {
                return BadRequest("There is no category with this id");
            }
            commercecontext.Categories.Remove(category);
            commercecontext.SaveChanges();

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
