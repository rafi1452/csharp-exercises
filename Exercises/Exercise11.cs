using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


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
                if (!species_names.Contains(rowData[4]))
                {
                    species_names.Add(rowData[4]);
                }
                SqlCommand cmd = new SqlCommand("insert into species.dbo.iris values(" + float.Parse(rowData[0])
                    + "," + float.Parse(rowData[1]) + "," + float.Parse(rowData[2]) + "," +
                    float.Parse(rowData[3]) + ",'" + rowData[4] + "');", conn);
                cmd.ExecuteNonQuery();
            }
            foreach (string name in species_names)
            {
                List<string> props = new List<string>() {"sl","sw","pl","pw" };
                Console.WriteLine("\n" + name.ToUpper());
                foreach (string prop in props)
                {
                    string retrieveQuery = $"SELECT MIN({prop}), MAX({prop}), AVG({prop}) from species.dbo.iris where species_name = '" + name + "';";
                    SqlCommand cmd = new SqlCommand(retrieveQuery, conn);
                    using SqlDataReader rdr = cmd.ExecuteReader();
                    Console.WriteLine("--->" + prop);
                    while (rdr.Read())
                    {
                        
                        Console.WriteLine($" min = {rdr.GetDouble(0)}");
                        Console.WriteLine($" max = {rdr.GetDouble(1)}");
                        Console.WriteLine($" avg = {rdr.GetDouble(2).ToString("0.00")}");
                    }
                }
            }
            conn.Close();
        }
        Console.ReadLine();
    }
}


