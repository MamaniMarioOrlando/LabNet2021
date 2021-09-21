using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NorthwindService.Models;
using NorthwindService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NorthwindController : Controller
    {
        #region Properties
        private readonly OrdersRepository _ordersRepository;
        private readonly CustomersRepository _customersRepository;
        private readonly IConfiguration _configuration;
        #endregion

        #region Contructor
        public NorthwindController(
            OrdersRepository ordersRepository,
            CustomersRepository customersRepository,
            IConfiguration configuration
            )
        {
            _ordersRepository = ordersRepository;
            _customersRepository = customersRepository;
            _configuration = configuration;
        }
        #endregion

        #region Public Methods
        [HttpGet("GetOrders/{orderId}")]
        public List<Order> GetOrdersById(int orderId)
        {
            try
            {
                List<Order> order = _ordersRepository.Find(x => x.OrderId == orderId)
                                                      .Include(x => x.Customer)
                                                      .ToList();
                return order;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet("GetCustomerById/{customerId}")]
        public List<Customer> GetCustomerById(string customerId)
        {
            try
            {
                List<Customer> customer = _customersRepository.Find(x => x.CustomerId == customerId)
                                                              .ToList();
                return customer;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost("AddOrEditOrder")]
        public IActionResult AddOrEditOrder(Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (order.OrderId == 0)
                    {
                        _ordersRepository.Add(order);
                    }
                    else
                    {
                        _ordersRepository.Edit(order);
                    }

                    _ordersRepository.Save();
                }

                return Ok(order);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost("AddOrEditCustomer")]
        public IActionResult AddOrEditCustomer(Customer customer)
        {
            try
            {
                var customerBase = _customersRepository.Find(x => x.CustomerId == customer.CustomerId).FirstOrDefault();


                if (ModelState.IsValid)
                {
                    if (customerBase == null)
                    {
                        _customersRepository.Add(customer);
                    }
                    else
                    {
                        _customersRepository.Edit(customer);
                    }

                    _customersRepository.Save();
                }

                return Ok(customer);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost("DeleteOrder")]
        public IActionResult DeleteOrder(Order order)
        {
            try
            {
                _ordersRepository.Delete(order);
                _ordersRepository.Save();

                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost("DeleteCustomer")]
        public IActionResult DeleteCustomer(Customer customer)
        {
            try
            {
                _customersRepository.Delete(customer);
                _customersRepository.Save();

                return Ok();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

    }
}
