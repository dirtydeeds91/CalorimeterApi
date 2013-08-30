using System;
using System.Runtime.Serialization;

namespace Nutrition.WebApi.Models
{
    [DataContract]
    public class ProductModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "calories")]
        public double? Calories { get; set; }

        [DataMember(Name = "carbohydrates")]
        public double? Carbohydrates { get; set; }

        [DataMember(Name = "fats")]
        public double? Fats { get; set; }

        [DataMember(Name = "proteins")]
        public double? Proteins { get; set; }

        [DataMember(Name = "sugars")]
        public double? Sugars { get; set; }

        [DataMember(Name = "serving")]
        public double? Serving { get; set; }
    }
}