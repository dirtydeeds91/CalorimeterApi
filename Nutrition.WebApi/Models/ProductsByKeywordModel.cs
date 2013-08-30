using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Nutrition.WebApi.Models
{
    [DataContract]
    public class ProductsByKeywordModel
    {
        public ProductsByKeywordModel()
        {
            this.Products = new HashSet<ProductModel>();
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "keyword")]
        public string Keyword { get; set; }

        [DataMember(Name = "products")]
        public ICollection<Nutrition.WebApi.Models.ProductModel> Products { get; set; }
    }
}