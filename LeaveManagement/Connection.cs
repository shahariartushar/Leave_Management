using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace LeaveManagement
{
    class Connection
    {
        public SqlConnection thisConnection = new SqlConnection("Data Source=RKO-PC;Initial Catalog=LeaveManagement;Integrated Security=True");
    }
}
