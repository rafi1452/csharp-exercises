using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataConection
{
    class program
    {
        static async Task Main(string[] args)
        {

            Exercise13 ex = new Exercise13();
            //await ex.run();
            await ex.GetUrlContentLengthAsync();
            //await ex.GetDotNetCount();
            //ex.groupby();
            //ex.entityfw();
            //ex.calc("setosa", "sepal_length", "min");
            //ex.EFmysql();
        }
    }
}