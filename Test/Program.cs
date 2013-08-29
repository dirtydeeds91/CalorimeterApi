using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calorimeter.Data;
using ExcelReader;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExcelReader.ExcelReader reader = new ExcelReader.ExcelReader();
            //reader.ReadExcelReports();

            using (var calorimeter = new CalorimeterEntities())
            {
                var test = calorimeter.Products.First(p => p.ProductId == 69);
                Console.WriteLine(test.ProductName);
                Console.WriteLine(test.Proteins);
            }

        }
    }
}
