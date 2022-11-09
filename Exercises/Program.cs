using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataConection
{
    class program
    {
        static void Main(string[] args)
        {
            
            Exercise11 ex= new Exercise11();
            ex.run();
            //ex.groupby();
            ex.entityfw();          
        }
    }
}