//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nutrition.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Description
    {
        public Description()
        {
            this.Products = new HashSet<Product>();
        }
    
        public int DescriptionId { get; set; }
        public string KeyWord { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }
}
