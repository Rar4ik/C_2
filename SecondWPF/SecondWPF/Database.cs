using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace SecondWPF
{
    static class Database
    {
        static string connectionString =
               @"Data Source=(localdb)\MSSQLLocalDB;            
            Initial Catalog=Lesson 7;
            Integrated Security=True";
        public static void FilltheTable()
        {
            //string createStoredProc = @"CREATE PROCEDURE [dbo].[Table] AS SELECT * FROM [dbo].[Table]";
            string sqlExpression = @"INSERT INTO WORKERS (ID, SURNAME, AGE, SALARY, DEPARTMENT) VALUES
                                    ('1', 'Smirnov', '29', '12000', 'MARKETING');
                                    INSERT INTO WORKERS (ID, SURNAME, AGE, SALARY, DEPARTMENT) VALUES
                                    ('2', 'Ivanov', '23', '12000', 'Accounting');
                                    INSERT INTO WORKERS (ID, SURNAME, AGE, SALARY, DEPARTMENT) VALUES
                                    ('3', 'Sidorov', '30', '12000', 'Programming');
                                    INSERT INTO WORKERS (ID, SURNAME, AGE, SALARY, DEPARTMENT) VALUES
                                    ('4', 'Yarik', '29', '11000', 'MARKETING');
                                    INSERT INTO WORKERS (ID, SURNAME, AGE, SALARY, DEPARTMENT) VALUES
                                    ('5', 'Smirnov', '29', '12000', 'MARKETING')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {                
                connection.Open();
                //SqlCommand command = new SqlCommand(createStoredProc, connection);
                //int number = command.ExecuteNonQuery();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();                
            }
        }

        static public ObservableCollection<Workers> Workers { get; set; }
        static public ObservableCollection<Deps> Deps { get; set; }
        static Database()
        {
        }
    }    
}
