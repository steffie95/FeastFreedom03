using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeastFreedom03.Models
{
    public partial class OrderModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderModel()
        {
            //this.Details = new HashSet<OrderDetail>();
            //this.Items = new HashSet<Item>();

        }

        public Item Items { get; set; }

      
        public OrderDetail Details { get; set; }


    }
}