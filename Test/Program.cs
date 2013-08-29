using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calorimeter.Data;
using ExcelReader;
using Nutrition.Data;
using System.Diagnostics;

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
            
            using (var calorimeter = new CalorimeterEntities())
            //using (var calorimeter = new NutritionContext())
            {
                var test = calorimeter.Products.First(p => p.ProductId == 69);
                Console.WriteLine(test.ProductName);
                Console.WriteLine(test.Proteins);
            }

            //c.Stop();
            //Console.WriteLine(c.Elapsed);

        }
    }
}
