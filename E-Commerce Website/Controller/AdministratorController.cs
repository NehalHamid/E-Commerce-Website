using AutoMapper;
using E_Commerce_Website.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Website.Controller
{
    [Route("api/[controller]")]
    [ApiController ]
    
    public class AdministratorController : ControllerBase
    {
        E_CommerceContext commerceContext;
        IMapper mapper;
        public AdministratorController(E_CommerceContext _context, IMapper _mapper)
        {
            commerceContext = _context;
            mapper = _mapper;

        }
        [HttpPost ("Login")]
        public ActionResult login(AdminLogin admin )
        {
            var Administrator = commerceContext.Administrators.Where(x => x.e_mail == admin.e_mail && x.password == admin.password).FirstOrDefault();
            if (Administrator == null)
            {
                return Unauthorized("Invalid UserName or Password");
            }
                return Ok (Administrator);
        }
    }
}
