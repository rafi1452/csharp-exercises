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
    
}



