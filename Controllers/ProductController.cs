using Inverntory_Managment_System.DataAccess;
using Inverntory_Managment_System.Entity;
using Inverntory_Managment_System.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inverntory_Managment_System.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index(ProductVM model)
        {
            int loggedUserId = Convert.ToInt32(this.HttpContext.Session.GetString("LoggedUserId"));

            model.Page = model.Page <= 0 ? 1 : model.Page;
            model.ItemsPerPage = model.ItemsPerPage <= 0 ? 10 : model.ItemsPerPage;

            double Upprice=  Convert.ToDouble(model.PriceUp);
            double DownPrice = Convert.ToDouble(model.PriceDown);
            Expression<Func<Product, bool>> filter = p =>
           (string.IsNullOrEmpty(model.Name) || p.Name.Contains(model.Name)) &&
           (string.IsNullOrEmpty(model.PriceDown) || p.Price >= DownPrice) &&
           (string.IsNullOrEmpty(model.PriceUp) || p.Price <= Upprice);
            //   Expression<Func<Product, bool>> filter = p =>
            //   (string.IsNullOrEmpty(model.PriceUp) || p.Price.

            //  Expression<Func<Product, bool>> filter = p =>
            //   (u.UserId == loggedUserId) &&
            //   (string.IsNullOrEmpty(model.Name) || p.Name.Contains(model.Name));
            //(string.IsNullOrEmpty(model.Amount) || p.Amount.Contains(model.Amount))
            //   (string.IsNullOrEmpty(model.PriceUp) || p.Price.Contains(model.PriceUp));





            ProductRepository repo = new ProductRepository();
            model.Items = repo.GetAll(filter, model.Page, model.ItemsPerPage);

            model.PagesCount = (int)Math.Ceiling(repo.Count(filter) / (double)model.ItemsPerPage);

            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductVM model)
        {
            int loggedUserId = Convert.ToInt32(this.HttpContext.Session.GetString("LoggedUserId"));

            if (!ModelState.IsValid)
                return View(model);

            InventoryDbContext context = new InventoryDbContext();
            ProductRepository ProductRepository = new ProductRepository();
            Product item = new Product();
            item.UserId = loggedUserId;
            item.Name = model.Name;
            item.Price = model.Price;
            item.Amount = model.Amount;
            item.Description = model.Description;

           /* Product duplicateProduct = ProductRepository.GetFirstOrDefault(c => c.Description == item.Description);
            if (duplicateProduct != null)
            {
                ModelState.AddModelError("Email", "*Duplicate email");
                return View(model);
            }*/

            ProductRepository.Insert(item);

            return RedirectToAction("Index", "Product");
        }

        // GET: ProductController/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
           
            ProductRepository contactRepository = new ProductRepository();

            Product item = contactRepository.GetFirstOrDefault(u => u.Id == id);

            EditingHistoryRepository editingHistoryRepository = new EditingHistoryRepository();



            if (item == null)
                return RedirectToAction("Index", "Product");

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.UserId = item.UserId;
            model.Name = item.Name;
            model.Price = item.Price;
            model.Description = item.Description;
            model.Amount = item.Amount;


          
            model.OldName = item.Name;
            model.OldPrice = item.Price;
            model.OldDescription = item.Description;
            model.OldAmount = item.Amount;
            model.ProductId = item.Id;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            int loggedUserId = Convert.ToInt32(this.HttpContext.Session.GetString("LoggedUserId"));
            if (!ModelState.IsValid)
                return View(model);

            ProductRepository contactRepository = new ProductRepository();
            EditingHistoryRepository editingHistoryRepository = new EditingHistoryRepository();
            EditingHistory editingHistory = new EditingHistory();

            Product item = new Product();
            item.Id = model.Id;
            item.UserId = model.UserId;
            item.Name = model.Name;
            item.Price = model.Price;
            item.Description = model.Description;
            item.Amount = model.Amount;

            editingHistory.UserId = loggedUserId;
            editingHistory.ProductId = model.ProductId;
            editingHistory.OldName = model.OldName;
            editingHistory.OldPrice = model.OldPrice;
            editingHistory.OldAmount = model.OldAmount;
            editingHistory.Name = model.Name;
            editingHistory.Price = model.Price;
            editingHistory.Amount = model.Amount;
            editingHistory.Description = model.Description;
            editingHistory.OldDescription = model.OldDescription;
          
            editingHistoryRepository.Insert(editingHistory);
            contactRepository.Update(item);

            return RedirectToAction("Index", "Product");
        }

        // GET: ProductController/Delete/5
        public IActionResult Delete(int id)
        {
            ProductRepository contactRepository = new ProductRepository();

            Product item = new Product();
            item.Id = id;

            //context.Users.Remove(item);
            //or
            //context.Entry(item).State = EntityState.Deleted;
            contactRepository.Delete(item);


            return RedirectToAction("Index", "Product");
        }

        // POST: ProductController/Delete/5
        [HttpGet]
        public IActionResult Sell(int id)
        {
            ProductRepository contactRepository = new ProductRepository();
            Product item = new Product();
            item.Id = id;
            EditVM model = new EditVM();
            model.Id = item.Id;
            model.UserId = item.UserId;
            model.Name = item.Name;
            model.Price = item.Price;
            model.Description = item.Description;
            model.Amount = item.Amount;


            return RedirectToAction("Index", "Product");
        }
        [HttpPost]
        public IActionResult Sell(SellVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            ProductRepository contactRepository = new ProductRepository();

            Product item = new Product();
            item.Id = model.Id;
            item.UserId = model.UserId;
            item.Name = model.Name;
            item.Price = model.Price;
            item.Description = model.Description;
            item.Amount = model.Amount;
            contactRepository.Update(item);

            return RedirectToAction("Index", "Product");
        }
    }
}
