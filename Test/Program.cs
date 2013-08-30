using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutrition.Data;
using System.Diagnostics;
using Nutrition.WebApi.Models;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExcelReader.ExcelReader reader = new ExcelReader.ExcelReader();
            //reader.ReadExcelReports();
            
            //var c = new Stopwatch();
            //c.Start();
            
            //using (var calorimeter = new CalorimeterEntities())
            using (var context = new NutritionContext())
            {
                var models = new HashSet<ProductsByKeywordModel>();
                var keywordEntities = context.Descriptions;

                var c = new Stopwatch();
                c.Start();

                foreach (var keywordEntity in keywordEntities)
                {
                    var productsByKeywordModel = Parser.ParseProductsByKeyword(keywordEntity);
                    models.Add(productsByKeywordModel);
                    Console.WriteLine(productsByKeywordModel.Keyword);
                }

                c.Stop();
                Console.WriteLine(c.Elapsed);

                //var test = calorimeter.Products.First(p => p.ProductId == 69);
                //Console.WriteLine(test.ProductName);
                //Console.WriteLine(test.Proteins);
                //Console.WriteLine(test.Serving);
                //foreach (var tag in test.Descriptions)
                //{
                //    Console.WriteLine(tag.KeyWord);
                //}
            }

            //c.Stop();
            //Console.WriteLine(c.Elapsed);

        }
    }
}
