//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FeastFreedom03.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KitchenHOOp
    {
        public int HOOpID { get; set; }
        public int KitchenID { get; set; }
        public bool openMon { get; set; }
        public bool openTues { get; set; }
        public bool openWeds { get; set; }
        public bool openThurs { get; set; }
        public bool openFri { get; set; }
        public bool openSat { get; set; }
        public bool openSun { get; set; }
        public System.TimeSpan openTime { get; set; }
        public System.TimeSpan closeTime { get; set; }
    
        public virtual Kitchen Kitchen { get; set; }
    }
}
