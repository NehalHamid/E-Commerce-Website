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
    [ApiController]
    public class OrderController :ControllerBase
    {
       
        E_CommerceContext commerceContext;
        IMapper mapper;
        public OrderController(E_CommerceContext _context, IMapper _mapper)
        {
            commerceContext = _context;
            mapper = _mapper;

        }

        List<Order> orders = new List<Order>();
        List<Order_Item> ordersItems = new List<Order_Item>();


        [HttpPost("AddOrder")]
        public ActionResult addOrder(Addorder order)
        {
            Order ord = new Order();
            ord.customerid = order.customerid;
            ord.date = DateTime.Now;

            orders.Add(ord);

            foreach (var item in order.list)
            {
                Order_Item itemo = new Order_Item();
                itemo.productid = (int)item.productid;
                itemo.qty = item.qty;
                itemo.orderid = ord.id;

                ordersItems.Add(itemo);
            }

            return Ok("done");
        }


        [HttpDelete("DeleteOrder")]
        public ActionResult DeleteOrder([FromBody] int Id)
        {
            var order = commerceContext.Orders.Find(Id);
            if (order == null)
            {
                return BadRequest("There is no order with this id");
            }

            commerceContext.Orders.Remove(order);
            commerceContext.SaveChanges();

            return Ok("Done");
        }


    }
}
