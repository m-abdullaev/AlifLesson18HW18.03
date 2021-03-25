using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace AlifLesson18HW18._03.Repos
{
    class RepositoryBase<T>
    {
        public string conString { get; private set; }
        public RepositoryBase()
        {
            conString = "Data source = DESKTOP-SS5TGJO\\SQLEXPRESS; initial catalog = Person1; Integrated security = true;";
        }
        public List<T> SelectAll()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(conString))
                {
                    return db.Query<T>($"select * from Persons").ToList();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

    }   
}
