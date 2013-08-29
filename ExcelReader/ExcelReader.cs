using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel;
using System.IO;
using System.Data;
using Nutrition.Data;
using System.Threading;

namespace ExcelReader
{
    public class ExcelReader
    {
        public void ReadExcelReports()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            FileStream stream = File.Open(@"..\..\..\nutrition.xlsx", FileMode.Open, FileAccess.Read);

            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();

            while (excelReader.Read())
            {
                var productName = excelReader.GetString(0);
                var calories = excelReader.GetValue(1);
                var protein = excelReader.GetValue(2);
                var fat = excelReader.GetValue(3);
                var carbs = excelReader.GetValue(4);
                var sugar = excelReader.GetValue(5);
                var description = productName.Split(',');
                List<string> descriptionTag = new List<string>();
                descriptionTag.AddRange(description);
                //descriptionTag.Add(description[0]);
                //if (description.Length > 1)
                //{
                //    descriptionTag.Add(description[1]);
                //}

                //null checks
                if (calories == null)
                {
                    calories = 0;
                }
                if (protein == null)
                {
                    protein = 0;
                }
                if (fat == null)
                {
                    fat = 0;
                }
                if (carbs == null)
                {
                    carbs = 0;
                }
                if (sugar == null)
                {
                    sugar = 0;
                }

                using (NutritionContext db = new NutritionContext())
                {
                    var productToAdd = new Product()
                    {
                        ProductName = productName,
                        Calories = double.Parse(calories.ToString()),
                        Carbohydrates = double.Parse(carbs.ToString()),
                        Fats = double.Parse(fat.ToString()),
                        Proteins = double.Parse(protein.ToString()),
                        Sugars = double.Parse(sugar.ToString()),
                    };

                    db.Products.Add(productToAdd);
                    //db.SaveChanges();

                    foreach (var tag in descriptionTag)
                    {
                        Description desc = new Description()
                        {
                            KeyWord = tag,
                        };

                        var existingTag = db.Descriptions.FirstOrDefault(x => x.KeyWord == tag);
                        if (existingTag == null)
                        {
                            db.Descriptions.Add(desc);
                            desc.Products.Add(productToAdd);
                        }
                        else
                        {
                            productToAdd.Descriptions.Add(existingTag);
                        }
                    };
                    Console.WriteLine("Added product " + productToAdd.ProductName + ", " + productToAdd.Sugars);
                    db.SaveChanges();
                }
            }

            excelReader.Close();
        }
    }
}
