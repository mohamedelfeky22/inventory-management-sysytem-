//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Warhouse_Product
    {
        public string War_Name { get; set; }
        public int Prod_Id { get; set; }
        public Nullable<int> Prod_Quantity { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
