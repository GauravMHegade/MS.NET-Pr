using Microsoft.Data.SqlClient;

namespace Assignment_User_Validation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=User;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionString);




            #region Check User Validation

            //Console.WriteLine("Enter UserName");
            //string uname = Console.ReadLine();

            //Console.WriteLine("Enter Password");
            //string password = Console.ReadLine();
            //string validQuery = $"select * from [user] where uname='{uname}' and password='{password}'";

            //SqlCommand cmd = new SqlCommand(validQuery, conn);

            //conn.Open();

            //SqlDataReader reader = cmd.ExecuteReader();
            ////if (reader != null)//this condition is always true bcz if rows cannot be affected ExecuteReader() returns -1(i.e. not null)
            //if (reader.HasRows)
            //{
            //    Console.WriteLine("Valid User");
            //    Console.WriteLine($"Access Granted to User: {uname}");
            //}
            //else
            //{
            //    Console.WriteLine("Invalid User");
            //}

            //conn.Close();
            #endregion

            #region Add New User
            //Console.WriteLine("To Add new User");
            //Console.WriteLine("Enter Username");
            //string uName = Console.ReadLine();
            //Console.WriteLine("Enter Password");
            //string Pass = Console.ReadLine();

            //string insertQuery = $"insert into [user](uname, password) values('{uName}','{Pass}')";

            //SqlCommand cmd = new SqlCommand(insertQuery, conn);

            //conn.Open();
            //int noOfRows = cmd.ExecuteNonQuery();
            //if (noOfRows > 0)
            //{
            //    Console.WriteLine("User added successfully...");
            //}
            //else
            //{
            //    Console.WriteLine("Error");
            //}
            //conn.Close(); 
            #endregion


            //Console.WriteLine("Enter UserName for change your password");
            //string uName = Console.ReadLine();
            //Console.WriteLine("Enter New Password");
            //string pass = Console.ReadLine();

            //string updateQuery = $"update [user] set password='{pass}' where uname = '{uName}'";

            //SqlCommand cmd = new SqlCommand(updateQuery, conn);

            //conn.Open();

            //int noOfRows = cmd.ExecuteNonQuery();

            //if (noOfRows > 0)
            //{
            //    Console.WriteLine("PassWord Updated successfully...");
            //}
            //else
            //{
            //    Console.WriteLine($"cannot find user with username = '{uName}'");
            //}

            //conn.Close();

            Console.WriteLine("Enter UserName for change your password");
            string uName = Console.ReadLine();

            String searchQuery = $"select * from [user] where uname='{uName}'";

            SqlCommand cmd = new SqlCommand(searchQuery, conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                conn.Close();
                Console.WriteLine("Enter new password");
                string pass = Console.ReadLine();

                string updateQuery = $"update [user] set password = '{pass}' where uname = '{uName}' ";
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(updateQuery, conn);
                int noOfRows = cmd1.ExecuteNonQuery();

                if (noOfRows > 0)
                {
                    Console.WriteLine("PassWord Updated successfully...");
                }
                conn.Close();

            }
            else
            {
                Console.WriteLine($"cannot find user with username = '{uName}'");
                //conn.Close();
            }
            conn.Close();

        }
    }
}
