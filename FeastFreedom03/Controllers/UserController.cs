using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FeastFreedom03.Models;
//using FeastFreedom03.Models.ViewModels;



namespace FeastFreedom03.Controllers
{
  
    public class UserController : Controller
    {
        private FeastFreedomEntities1 db = new FeastFreedomEntities1();

        // GET: User
        
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserName,UserEmail,UserPassword,SQAnswer1,SQAnswer2")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,UserEmail,UserPassword,SQAnswer1,SQAnswer2")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////
        /* UserController code written on 1/27/2020 goes below here*/

        public ActionResult Order()
        {
            FeastFreedomEntities1 db = new FeastFreedomEntities1();

            
                      return View();
        }






























        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /*
        [HttpGet]
        public ActionResult OrderPage() 
        {
            OrderModelContext orderModel = new OrderModelContext();
            List<Item> menuItems = db.Items.ToList();
            OrderModel oModel = new OrderModel();
            List<OrderModel> oModelList = new List<OrderModel>();
            //menuItems.ConvertAll(<Item>, <OrderModel>)
           // oModelList.Add(menuItems);
            List <OrderModelContext>  orderModelList = new List<OrderModelContext>();
            
            orderModelList.Add(orderModel);
            IEnumerable<OrderModelContext> enumList = orderModelList;
            Console.WriteLine(oModel.Items);
            return View(enumList);
        }
        */
     /*   public ActionResult Orderer()  //As of now, this method simply displays all them items to the user. No shopping functionality added yet.
        {
            List<Item> menuItems = db.Items.ToList();
            return View(menuItems);
            
        } */
    }
}
