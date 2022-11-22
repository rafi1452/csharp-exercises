using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Quartz.Util;
using SixLabors.ImageSharp.Drawing;
using static System.Formats.Asn1.AsnWriter;
using System.Runtime.Intrinsics.Arm;
using Exercises.Models;
using System.Reflection.Metadata.Ecma335;
using SixLabors.ImageSharp;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SpecFlow.Internal.Json;
using System.Text.Json;
using Microsoft.VisualBasic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using Exercises.DataObjects;

public class Exercise11
{
    public Exercise11()
    {
    }

    public void run()
    {

        using (SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=species;Integrated Security=True"))
        {
            conn.Open();
            string[] lines = File.ReadAllLines(@"C:\Users\Admin\Desktop\iris.csv");
            List<string> species_names = new List<string>();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] rowData = lines[i].Split(',');
                if (!species_names.Contains(rowData[rowData.Length - 1]))
                {
                    species_names.Add(rowData[rowData.Length - 1]);
                }
                SqlCommand cmd = new SqlCommand("insert into species.dbo.iris values(" + float.Parse(rowData[0])
                    + "," + float.Parse(rowData[1]) + "," + float.Parse(rowData[2]) + "," +
                    float.Parse(rowData[3]) + ",'" + rowData[4] + "');", conn);
                cmd.ExecuteNonQuery();
            }

            foreach (string name in species_names)
            {
                string[] props = new string[] { "sl", "sw", "pl", "pw" };
                Console.WriteLine($"\n ---- {name.ToUpper()}\n\tmin\tmax\tavg");
                foreach (string prop in props)
                {
                    string retrieveQuery = $"SELECT MIN({prop}), MAX({prop}), AVG({prop}) from species.dbo.iris where species_name = '{name}'";
                    SqlCommand cmd = new SqlCommand(retrieveQuery, conn);
                    using SqlDataReader rdr = cmd.ExecuteReader();
                    Console.Write("" + prop);
                    while (rdr.Read())
                    {
                        Console.Write($"\t{rdr.GetDouble(0).ToString("0.00")}");
                        Console.Write($"\t{rdr.GetDouble(1).ToString("0.00")}");
                        Console.WriteLine($"\t{rdr.GetDouble(2).ToString("0.00")}");
                    }
                }
            }
            conn.Close();
        }
    }


    //using single line sql query

    public void groupby()
    {
        using (SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=species;Integrated Security=True"))
        {
            conn.Open();
            string[] lines = File.ReadAllLines(@"C:\Users\Admin\Desktop\iris.csv");
            List<string> species_names = new List<string>();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] rowData = lines[i].Split(',');
                if (!species_names.Contains(rowData[rowData.Length - 1]))
                {
                    species_names.Add(rowData[rowData.Length - 1]);
                }
                SqlCommand cmd = new SqlCommand("insert into species.dbo.iris values(" + float.Parse(rowData[0])
                    + "," + float.Parse(rowData[1]) + "," + float.Parse(rowData[2]) + "," +
                    float.Parse(rowData[3]) + ",'" + rowData[4] + "');", conn);
                cmd.ExecuteNonQuery();
            }



            string retrieveQuery = "SELECT species_name, min(sl) as min_sl, max(sl) as max_sl,avg(sl) as avg_sl,min(sw) as min_sw,max(sw) as max_sw, avg(sw) as avg_sw,min(pl) as min_pl, max(pl) as max_pl,avg(pl) as avg_pl,min(pw) as min_pw,max(pw) as max_pw, avg(pw) as avg_pw FROM iris GROUP BY species_name";
            SqlCommand speciesCmd = new SqlCommand(retrieveQuery, conn);
            using SqlDataReader rdr = speciesCmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr.GetString(0));
                Console.WriteLine("     min       max       avg");
                Console.Write("sl   ");
                Console.Write(rdr.GetDouble(1).ToString("0.00") + "      ");
                Console.Write(rdr.GetDouble(2).ToString("0.00") + "      ");
                Console.WriteLine(rdr.GetDouble(3).ToString("0.00"));

                Console.Write("sw   ");
                Console.Write(rdr.GetDouble(4).ToString("0.00") + "      ");
                Console.Write(rdr.GetDouble(5).ToString("0.00") + "      ");
                Console.WriteLine(rdr.GetDouble(6).ToString("0.00"));

                Console.Write("pl   ");
                Console.Write(rdr.GetDouble(7).ToString("0.00") + "      ");
                Console.Write(rdr.GetDouble(8).ToString("0.00") + "      ");
                Console.WriteLine(rdr.GetDouble(9).ToString("0.00"));

                Console.Write("pw   ");
                Console.Write(rdr.GetDouble(10).ToString("0.00") + "      ");
                Console.Write(rdr.GetDouble(11).ToString("0.00") + "      ");
                Console.WriteLine(rdr.GetDouble(12).ToString("0.00"));
                Console.WriteLine();
            }
        }
    }
    public void entityfw()
    {
        using (FlowersDbContext context = new FlowersDbContext())
        {
            var groupbyTable = from row in context.Irises
                               group row by row.Species into grouping
                               select new
                               {
                                   Key = grouping.Key,
                                   slMin = grouping.Min(item => item.SepalLength),
                                   slMax = grouping.Max(item => item.SepalLength),
                                   slAvg = grouping.Average(item => item.SepalLength),

                                   swMin = grouping.Min(item => item.SepalWidth),
                                   swMax = grouping.Max(item => item.SepalWidth),
                                   swAvg = grouping.Average(item => item.SepalWidth),

                                   plMin = grouping.Min(item => item.PetalLength),
                                   plMax = grouping.Max(item => item.PetalLength),
                                   plAvg = grouping.Average(item => item.PetalLength),

                                   pwMin = grouping.Min(item => item.PetalWidth),
                                   pwMax = grouping.Max(item => item.PetalWidth),
                                   pwAvg = grouping.Average(item => item.PetalWidth),
                               };
            groupbyTable.AsQueryable();
            foreach (var group in groupbyTable)
            {
                Console.WriteLine(group.Key);
                Console.WriteLine("     min     max     avg");
                Console.Write("sl   " + group.slMin.ToString("0.00"));
                Console.Write("    " + group.slMax.ToString("0.00"));
                Console.WriteLine("    " + group.slAvg.ToString("0.00"));

                Console.Write("sw   " + group.swMin.ToString("0.00"));
                Console.Write("    " + group.swMax.ToString("0.00"));
                Console.WriteLine("    " + group.swAvg.ToString("0.00"));

                Console.Write("pl   " + group.plMin.ToString("0.00"));
                Console.Write("    " + group.plMax.ToString("0.00"));
                Console.WriteLine("    " + group.plAvg.ToString("0.00"));

                Console.Write("pw   " + group.pwMin.ToString("0.00"));
                Console.Write("    " + group.pwMax.ToString("0.00"));
                Console.WriteLine("    " + group.pwAvg.ToString("0.00") + "\n");

            }
        }
    }

    public double calc(string species, string prop, string type)
    {       
        double calc = 0;
        using (FlowersDbContext context = new FlowersDbContext())
        {            
            IQueryable<double> calcquery ;
            if (prop == "sepal_length")
            {
                calcquery = from row in context.Irises
                           where row.Species == species
                           select row.SepalLength;
            }
            else if (prop == "sepal_width")
            {
                calcquery = from row in context.Irises
                           where row.Species == species
                           select row.SepalWidth;
            }
            else if (prop == "petal_length")
            {
                calcquery = from row in context.Irises
                           where row.Species == species
                           select row.PetalLength;
            }
            else
            {
                calcquery = from row in context.Irises
                            where row.Species == species
                            select row.PetalWidth;
            }

            if (type == "min")
            {
                calc = calcquery.Min();
            }
            else if (type == "max")
            {
                calc = calcquery.Max();
            }
            else if (type == "avg")
            {
                calc = calcquery.Average();
            }           
        }
        calc = Math.Round(calc, 2);
        Console.WriteLine(calc);
        return calc;
    }


    public void EFmysql()
    {
        using (flowers_dbContext context = new flowers_dbContext())
        {
            var groupbyTable = from row in context.Irises
                               group row by row.Species into grouping
                               select new
                               {
                                   Key = grouping.Key,
                                   slMin = grouping.Min(item => item.SepalLength),
                                   slMax = grouping.Max(item => item.SepalLength),
                                   slAvg = grouping.Average(item => item.SepalLength),

                                   swMin = grouping.Min(item => item.SepalWidth),
                                   swMax = grouping.Max(item => item.SepalWidth),
                                   swAvg = grouping.Average(item => item.SepalWidth),

                                   plMin = grouping.Min(item => item.PetalLength),
                                   plMax = grouping.Max(item => item.PetalLength),
                                   plAvg = grouping.Average(item => item.PetalLength),

                                   pwMin = grouping.Min(item => item.PetalWidth),
                                   pwMax = grouping.Max(item => item.PetalWidth),
                                   pwAvg = grouping.Average(item => item.PetalWidth),
                               };
            groupbyTable.AsQueryable();
            foreach (var group in groupbyTable)
            {
                Console.WriteLine(group.Key);
                Console.WriteLine("     min     max     avg");
                Console.Write("sl   " + ((double)group.slMin).ToString("0.00"));
                Console.Write("    " + ((double)group.slMax).ToString("0.00"));
                Console.WriteLine("    " + ((double)group.slAvg).ToString("0.00"));

                Console.Write("sw   " + ((double)group.swMin).ToString("0.00"));
                Console.Write("    " + ((double)group.swMax).ToString("0.00"));
                Console.WriteLine("    " + ((double)group.swAvg).ToString("0.00"));

                Console.Write("pl   " + ((double)group.plMin).ToString("0.00"));
                Console.Write("    " + ((double)group.plMax).ToString("0.00"));
                Console.WriteLine("    " + ((double)group.plAvg).ToString("0.00"));

                Console.Write("pw   " + ((double)group.pwMin).ToString("0.00"));
                Console.Write("    " + ((double)group.pwMin).ToString("0.00"));
                Console.WriteLine("    " + ((double)group.pwAvg).ToString("0.##") + "\n");
            }
        }
    }
}




