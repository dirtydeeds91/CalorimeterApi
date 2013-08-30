using System;
using System.Linq;
using Nutrition.Data;

namespace Nutrition.WebApi.Assists
{
    public class Validator
    {
        public static Product ValidateProductId(NutritionContext context, int productId)
        {
            var product = context.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                throw new ArgumentNullException("ProductId dont't exists in the database");
            }

            return product;
        }

        internal static Description ValidateKeyword(NutritionContext context, string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                throw new ArgumentNullException("Keyword can't be empty ot with null value");
            }
            else if (keyword.Length < 3)
            {
                throw new InvalidOperationException("Keyword has to be at least 3 chars long");
            }

            var keywordInDb = context.Descriptions.FirstOrDefault(d => d.KeyWord.ToLower().Trim() == keyword.ToLower().Trim());
            if (keywordInDb == null)
            {
                throw new ArgumentNullException("Keyword don't exists in database");
            }

            return keywordInDb;
        }
    }
}