using IronXL;
using System.Linq;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;


public class Exercise10
{
    public Exercise10()
    {
    }

    public void run()
    {
        string[] lines = File.ReadAllLines("../../../data/iris.csv");

        /* x is dictionary 
          {
               setosa : {
                       sLen : [],
                       sWid : [],
                       pLen : [],
                       pWid : [],
                       count : 0
               },
               ...
        }
        */
        Dictionary<string, Dictionary<string, List<float>>> data
            = new Dictionary<string, Dictionary<string, List<float>>>();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] rowData = lines[i].Split(',');
            string species = rowData[rowData.Length - 1];

            if (!data.Keys.Contains(species))
            {   // adding a new species
                data.Add(species, new Dictionary<string, List<float>>());
                data[species].Add("sl", new List<float>());
                data[species].Add("sw", new List<float>());
                data[species].Add("pl", new List<float>());
                data[species].Add("pw", new List<float>());
            }
            data[species]["sl"].Add(float.Parse(rowData[0]));
            data[species]["sw"].Add(float.Parse(rowData[1]));
            data[species]["pl"].Add(float.Parse(rowData[2]));
            data[species]["pw"].Add(float.Parse(rowData[3]));
        }
        foreach (string species in data.Keys)
        {
            Console.WriteLine("\n" + species.ToUpper() + " ");
            foreach (string prop in data[species].Keys)
            {
                Console.WriteLine(" ------> " + prop);
                Console.WriteLine("max = " + data[species][prop].Max());
                Console.WriteLine("min = " + data[species][prop].Min());
                Console.WriteLine("mean = " + data[species][prop].Sum() / data[species][prop].Count);
            }
        }
    }


    public void run1()
    {
        IronXL.License.LicenseKey = "IRONXL.VENUTHAMMISETTY.15155-EEFE787324-CXHS6LZH2BRXPK5-MZ6LSJYTLNBI-JIQZTNRFRG4I-F43BQ3D6O4OG-CKKVAIOJJNBP-7AEL2A-TUCSGELLNSGIEA-DEPLOYMENT.TRIAL-55MIUP.TRIAL.EXPIRES.26.NOV.2022";

        //WorkBook workbook = WorkBook.LoadCSV(@"C:\Users\Admin\iris.csv");
        //WorkSheet sheet = workbook.DefaultWorkSheet;

        //decimal avg = sheet["A2:A51"].Avg();
        //decimal min = sheet["A2:A51"].Min();
        //decimal max = sheet["A2:A51"].Max();
        //Console.WriteLine($"avg = {avg},\nmin = {min} ,\nmax = {max} ");
        
            WorkBook wb = WorkBook.Load(@"C:\Users\Admin\iris.csv"); // Your Excel file Name
            WorkSheet ws = wb.DefaultWorkSheet;
            DataTable dt = ws.ToDataTable(true);//parse sheet1 of sample.xlsx file into datatable
            foreach (DataRow row in dt.Rows) //access rows
            {
                for (int i = 0; i < dt.Columns.Count; i++) //access columns of corresponding row
                {
                    Console.Write(row[i] + "  ");
                }
                Console.WriteLine();
            }


    }
}