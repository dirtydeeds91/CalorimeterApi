using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelReader;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ExcelReader.ExcelReader reader = new ExcelReader.ExcelReader();
            reader.ReadExcelReports();

        }
    }
}
