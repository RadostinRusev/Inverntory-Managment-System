using Inverntory_Managment_System.DataAccess;
using Inverntory_Managment_System.Entity;
using Inverntory_Managment_System.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inverntory_Managment_System.Controllers
{
    public class SellController : Controller
    {
        // GET: Sell
        [HttpGet]
        public ActionResult Index(int id)
        {
            int loggedUserId = Convert.ToInt32(this.HttpContext.Session.GetString("LoggedUserId"));
            SellVM model = new SellVM();

            ProductRepository productRepository = new ProductRepository();
            UserRepository userRepository = new UserRepository();

            model.product = productRepository.GetById(id);
            model.user = userRepository.GetById(loggedUserId);
            model.Name = model.product.Name;
            model.Price = model.product.Price;
            

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(SellVM model)
        {
            int loggedUserId = Convert.ToInt32(this.HttpContext.Session.GetString("LoggedUserId"));

            ProductRepository productRepository = new ProductRepository();
            UserRepository userRepository = new UserRepository();

            model.overallPrice = model.Price * model.Amount;
            model.user = userRepository.GetById(loggedUserId);


            return View(model);
        }

        // GET: Sell/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sell/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sell/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Sell/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sell/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Sell/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sell/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
