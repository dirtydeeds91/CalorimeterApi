using System;
using System.Linq;
using Nutrition.Data;
using Nutrition.WebApi.Models;

namespace Nutrition.WebApi.Assists
{
    public class Parser
    {
        public static ProductsByKeywordModel ParseProductsByKeyword(Description keywordEntity)
        {
            var model = new ProductsByKeywordModel();

            model.Id = keywordEntity.DescriptionId;
            model.Keyword = keywordEntity.KeyWord.ToLower().Trim();
            foreach (var product in keywordEntity.Products)
            {
                var productModel = ParseProduct(product);
                model.Products.Add(productModel);
            }

            return model;
        }

        public static ProductModel ParseProduct(Product productEntity)
        {
            var model = new ProductModel
            {
                Id = productEntity.ProductId,
                Name = productEntity.ProductName.ToUpper().Trim(),
                Calories = productEntity.Calories,
                Carbohydrates = productEntity.Carbohydrates,
                Fats = productEntity.Fats,
                Proteins = productEntity.Proteins,
                Sugars = productEntity.Sugars,
                Serving = productEntity.Serving
            };

            return model;
        }
    }
}