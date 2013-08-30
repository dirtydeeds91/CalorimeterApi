using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Nutrition.WebApi.Assists;
using Nutrition.WebApi.Models;
using Nutrition.Data;

namespace Nutrition.WebApi.Controllers
{
    public class NutritionsController : BaseApiController
    {
        // api/nutritions
        public IQueryable<ProductsByKeywordModel> GetAll()
        {
            var responseMsg = this.PerformOperationAndHandleExeptions(() =>
            {
                using (var context = new NutritionContext())
                {
                    var models = new HashSet<ProductsByKeywordModel>();
                    var keywordEntities = context.Descriptions;

                    foreach (var keywordEntity in keywordEntities)
                    {
                        var productsByKeywordModel = Parser.ParseProductsByKeyword(keywordEntity);
                        models.Add(productsByKeywordModel);
                    }

                    return models.OrderBy(p => p.Keyword).AsQueryable();
                }
            });

            return responseMsg;
        }

        // api/nutritions?keyword={keyword}
        public ProductsByKeywordModel GetProductsByKeyword([FromUri]string keyword)
        {
            var responseMsg = this.PerformOperationAndHandleExeptions(() =>
            {
                using (var context = new NutritionContext())
                {
                    var keywordEntity = Validator.ValidateKeyword(context, keyword);
                    var productModel = Parser.ParseProductsByKeyword(keywordEntity);
                    return productModel;
                }
            });

            return responseMsg;
        }

        // api/nutritions?productId={productId}
        public ProductModel GetProductById([FromUri]int productId)
        {
            var responseMsg = this.PerformOperationAndHandleExeptions(() =>
            {
                using (var context = new NutritionContext())
                {
                    var productEntity = Validator.ValidateProductId(context, productId);
                    var productModel = Parser.ParseProduct(productEntity);
                    return productModel;
                }
            });

            return responseMsg;
        }
    }
}
