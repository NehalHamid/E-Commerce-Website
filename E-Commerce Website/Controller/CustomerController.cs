using AutoMapper;
using E_Commerce_Website.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Website.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        E_CommerceContext commerceContext;
        IMapper mapper;
        public CustomerController(E_CommerceContext _context, IMapper _mapper)
        {
            commerceContext = _context;
            mapper = _mapper;

        }
        /*[HttpGet("GetALL")]
        public ActionResult getAll()
        {
            var lst = commerceContext.Customers;
            return Ok(lst);
        }*/

        [HttpPost ("Register")]
        public ActionResult Register(CustomerRegister register)
        {
            //Customer customer = mapper.Map<Customer>(register);
            Customer customer = new Customer
            {
                name = register.name,
                e_mail = register.e_mail,
                password = register.password,
                address = register.address,
                phone = register.phone
            };
            commerceContext.Customers.Add(customer);
            commerceContext.SaveChanges();
            return Ok("Done");
        }


        [HttpPost("Login")]
        public ActionResult login(CustomerLogin login )
        {
            var Customer = commerceContext.Customers.Where(x => x.e_mail == login.e_mail && x.password == login.password).FirstOrDefault();
            if (Customer  == null)
            {
                return Unauthorized("Invalid UserName or Password");
            }
            return Ok(Customer);
        }


        [HttpPut("UpdateProfile")]
        public ActionResult UpdateProfile([FromQuery] int Id, [FromBody] CustomerRegister customer)
        {

            var st = commerceContext.Customers.AsNoTracking().Where(c => c.id == Id).FirstOrDefault();


            if (st == null)
            {
                return BadRequest("not found");
            }

            Customer s = new Customer
            {
                id = Id,
                name = customer.name ?? st.name,
                e_mail = customer.e_mail ?? st.e_mail,
                password = customer.password ?? st.password,
                address=customer.address??st.address,
                phone=customer.phone??st.phone,
            };

            commerceContext.Customers.Update(s);
            commerceContext.SaveChanges();

            return Ok("done");
        }


        [HttpDelete("DeleteAccount")]
        public ActionResult DeleteAccount([FromForm] int Id)
        {

            var student = commerceContext.Customers.Where(s => s.id == Id).FirstOrDefault();

            if (student == null)
            {
                return BadRequest("there is no customer with this id");
            }

            commerceContext.Customers.Remove(student);
            commerceContext.SaveChanges();

            return Ok("done");
        }

    }
}
