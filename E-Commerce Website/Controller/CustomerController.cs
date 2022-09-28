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
        [HttpGet("GetALL")]
        public ActionResult getAll()
        {
            var lst = commerceContext.Customers;
            return Ok(lst);
        }
        [HttpPost ("Register")]
        public ActionResult Register(CustomerRegister register)
        {
            Customer customer = mapper.Map<Customer>(register);
            commerceContext.Customers.Add(customer);
            commerceContext.SaveChanges();
            return Ok("Done");
        }
        [HttpPost("Login")]
        public ActionResult login(CustomerLogin login )
        {
            var Customer = commerceContext.Customers .Where(x => x.e_mail == login .e_mail && x.password == login .password).FirstOrDefault();
            if (Customer  == null)
            {
                return Unauthorized("Invalid UserName or Password");
            }
            return Ok(Customer);
        }

    }
}
