using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_CustomerSuchenDB.Models;

namespace mvc_CustomerSuchenDB.Controllers
{
   
    public class HomeController : Controller
    {
        CustomerSearch objSearch = new CustomerSearch();
        NorthwindEntities entities = new NorthwindEntities();
        static string storage = "";     
   
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";            
            return View();
        }

       
        public ActionResult Kunde()
        {              
                return View();
        }

        public ActionResult GetCustomer(string searchCustomer)
        {           
            GetCustomers(searchCustomer);
            return View("Kunde", objSearch);    
        }

        public IQueryable<Customer> GetCustomers(string searchCustomer)
        {
           objSearch.customer = entities.Customers.Where(u => u.CompanyName.Contains(searchCustomer) || u.ContactName.Contains(searchCustomer));
            return objSearch.customer;
        }

        public IQueryable<Order> GetOrders(string id)
        {
            objSearch.orders = entities.Orders.Where(u => u.CustomerID == id);
            return objSearch.orders;
        }
        public IQueryable<Customer> GetDetails(string id)
        {
            objSearch.customer = entities.Customers.Where(u => u.CustomerID == id);
            return objSearch.customer;
        }

        public IQueryable<Order_Detail> GetOrderDetails(int id)
        {
            objSearch.orderDetails = entities.Order_Details.Where(x => x.OrderID == id);
            return objSearch.orderDetails;
        }

        public ActionResult Bestellungen(string id)
        {
            storage = id;               
            GetOrders(id);
            GetDetails(id);
            return View(objSearch);
        }

        public ActionResult BestellDetails(int id)
        {
            GetOrderDetails(id);
            GetDetails(storage);
            return View(objSearch);
        }
       
    }
}