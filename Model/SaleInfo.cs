//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SaleInfo
    {
        public int ID_Sale { get; set; }
        public string SaleDate { get; set; }
        public Nullable<int> ID_Manager { get; set; }
        public Nullable<int> ID_Client { get; set; }
        public Nullable<int> ID_Product { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Product Product { get; set; }
    }
}
