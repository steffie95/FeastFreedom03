using FeastFreedom03.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FeastFreedom03.Views.ViewModels
{
    
    public class OrderViewModel
    {
        public virtual Kitchen Kitchen { get; set; }

        public virtual Item Item { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
        public OrderViewModel() 
        {
            this.Kitchen = new Kitchen();
            this.Item = new Item();
            this.OrderDetail = new OrderDetail();
            this.Order = new Order();
            this.User = new User();
            this.OrderViewModelList = new List<OrderViewModel>();
        }
        

        public List<OrderViewModel> OrderViewModelList { get; set; } 
       /*
        public int ItemID { get; set; }

        public string ItemName { get; set; }

        public decimal ItemPrice { get; set; }

        public bool isVeg { get; set; }

        public int Quantity { get; set; }

        public int KitchenID { get; set; }
        public int OrderID { get; set; }

        public int DetailsID { get; set; }
        */
        
      

    }

}