using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FeastFreedom03.Models;
using FeastFreedom03.Views.ViewModels;
using AutoMapper;
#nullable enable


namespace FeastFreedom03.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        public ActionResult OrderSummary(List<OrderDetail> detailsList)
        {
            FeastFreedomEntities1 db = new FeastFreedomEntities1();
            return View(detailsList);
        }


        
        public ActionResult OrderComplete()
        {
            return View();
        }    


        [HttpGet]
        public ActionResult SelectKitchen()
        {
            FeastFreedomEntities1 db = new FeastFreedomEntities1();
            List<Kitchen> kitchenList = new List<Kitchen>();
            foreach (Kitchen kitchen in db.Kitchens)
            {
                kitchenList.Add(kitchen);
            }
            return View(kitchenList);
        }


        [HttpGet]
        public ActionResult OrderPage(int? kitchenID)
        {
            if (kitchenID != null)
            {
                FeastFreedomEntities1 context = new FeastFreedomEntities1();
                List<OrderViewModel> orderVModels = new List<OrderViewModel>();

                var itemList = (from i in context.Items
                                join k in context.Kitchens
                                on i.KitchenID equals kitchenID
                                select new { i.ItemName, i.ItemPrice, i.Kitchen.KitchenName, i.ItemID, i.isVeg }).ToList().Distinct();



                OrderViewModel ovmList = new OrderViewModel();
                foreach (var item in itemList)
                { 
                    OrderViewModel ovm = new OrderViewModel();
                    ovm.Item.ItemID = item.ItemID;
                    ovm.Item.ItemName = item.ItemName;
                    ovm.Item.ItemPrice = item.ItemPrice;
                    ovm.Item.isVeg = item.isVeg;
                    ovm.OrderDetail.Quantity = 0;
                    ovm.Kitchen.KitchenName = item.KitchenName;
                  
                    ovmList.OrderViewModelList.Add(ovm);     
                }
                return View(ovmList);
            }
             return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderPage(OrderViewModel _orderViewModels)
        {
            if (ModelState.IsValid)
            {
                FeastFreedomEntities1 db = new FeastFreedomEntities1();
             
                OrderDetail dList = new OrderDetail();
                for (int i = 0; i < _orderViewModels.OrderViewModelList.Count(); i++)
                {
                    if (_orderViewModels.OrderViewModelList[i].OrderDetail.Quantity > 0)
                    {
                        OrderDetail details = new OrderDetail();
                        details.ItemName = _orderViewModels.OrderViewModelList[i].Item.ItemName;
                        details.ItemID = _orderViewModels.OrderViewModelList[i].Item.ItemID;
                        details.ItemTotal = _orderViewModels.OrderViewModelList[i].Item.ItemPrice * _orderViewModels.OrderViewModelList[i].OrderDetail.Quantity;
                        details.ItemName = _orderViewModels.OrderViewModelList[i].Item.ItemName;
                        details.Quantity = _orderViewModels.OrderViewModelList[i].OrderDetail.Quantity;

                        
                        dList.OrderDetailList.Add(details);
                        db.OrderDetails.Add(details);

                        //db.SaveChanges();
                    }                  
               }
                return View("OrderSummary", dList);
            }
            return View();
        }

    }
}


/*vvvvvvvvvvvvvvvvv//////////////////////////////Scrap Code Below////////////////////////////////////////////////vvvvvvvvvvvvvv*/
/*
// GET: Order

/* public ActionResult Index()
 {
     FeastFreedomEntities1 db = new FeastFreedomEntities1();
     List<OrderViewModel> orderViewModel = new List<OrderViewModel>();
     return View();
 }
/*[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult OrderPage(OrderViewModel orderViewModel)
{
    FeastFreedomEntities1 db = new FeastFreedomEntities1();
    //OrderViewModel orderViewModel = new OrderViewModel();
    List<OrderViewModel> orderVModels = new List<OrderViewModel>();
    List<OrderDetail> detailsList = new List<OrderDetail>();
    /*if (ModelState.IsValid)
    {
        foreach (var item in orderViewModels)
        {
            OrderDetail details = new OrderDetail();
            if (item.Quantity > 0)
            {
                details.ItemID = item.ItemID;
                details.ItemTotal = item.ItemPrice * item.Quantity;
                detailsList.Add(details);
            }
        }
        return RedirectToAction("OrderSummary", detailsList);
    }
     return RedirectToAction("OrderSummary");
}
/* foreach (string key in form.AllKeys)
 {
     OrderDetail details = new OrderDetail();
     ViewBag.ItemName = form["ItemName"];
     details.ItemName = @ViewBag.ItemName;
     detailsList.Add(details);

 }


/* for (int i = 0; i<_orderViewModels.OrderViewModelList.Count(); i++)
       {
           if (_orderViewModels.OrderDetail.Quantity > 0)
           {

               OrderDetail details = new OrderDetail();
details.ItemName = Request["ItemName"];
               details.ItemID = item.Item.ItemID;
               details.ItemTotal = (item.Item.ItemPrice* item.OrderDetail.Quantity);
               details.ItemName = item.Item.ItemName;
               //details.UserID = User.Identity;
               detailsList.Add(details);
               db.OrderDetails.Add(details);

               db.SaveChanges();

           }*/






