using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly List<Customer> _customers;
        public CustomersController()
        {
            _customers = new List<Customer>()
            {
                new Customer()
                {
                    Id =1,
                    Name = "Customer 1"
                },
                 new Customer()
                {
                    Id =2,
                    Name = "Customer 2"
                },
                  new Customer()
                {
                    Id =3,
                    Name = "Customer 3"
                },
            };
        }
        // GET: Customers
        public ActionResult Index()
        {
            var viewModel = new RandomMovieViewModel {Customers = _customers};
            return View(viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customer = _customers.Find(c => c.Id == id);
            if (customer==null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}