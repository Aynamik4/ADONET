using ADONETDemo01.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ADONETDemo01
{
    class Program
    {
        static void Main(string[] args)
        {
            //SqlDataReaderDemo();
            //UpdateDemo();
            //DeleteDemo();
            SafeDeleteDemo("Valencia");
            //InsertDemo();
            //StoredProcedureDemo();
        }

        private static void StoredProcedureDemo()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection mercuryDB = new SqlConnection())
            {
                mercuryDB.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mercury;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                try
                {
                    mercuryDB.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "PersonalMedTitel";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Connection = mercuryDB;

                        // Add parameter.
                        SqlParameter parameter = new SqlParameter();
                        parameter.Value = "lagerarbetare";
                        parameter.ParameterName = "@titel";
                        parameter.SqlDbType = SqlDbType.VarChar;
                        parameter.Size = 32;
                        parameter.Direction = ParameterDirection.Input;
                        command.Parameters.Add(parameter);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Employee employee = new Employee()
                                {
                                    Namn = reader["Namn"].ToString(),
                                    Lön = (decimal)reader["Lön"],
                                    Titel = reader["Titel"].ToString()
                                };

                                employees.Add(employee);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                    //Console.WriteLine("Problem med SQL");
                }

                foreach (Employee employee1 in employees)
                {
                    Console.WriteLine(employee1);
                }
            }
        }

        private static void InsertDemo()
        {
            using (SqlConnection mercuryDB = new SqlConnection())
            {
                mercuryDB.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mercury;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                try
                {
                    mercuryDB.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "insert into Fruits values('Pear', 'Conference', 34.67)";
                        command.CommandType = CommandType.Text;
                        command.Connection = mercuryDB;
                        int rowsAffectd = command.ExecuteNonQuery();

                        if (rowsAffectd >= 1)
                            Console.WriteLine("En eller flera rader infogade!");
                        else
                            Console.WriteLine("Ingen rad infogad.");
                    }
                }
                catch (SqlException)
                {
                    Console.WriteLine("Problem med SQL");
                }
            }
        }

        private static void DeleteDemo()
        {
            using (SqlConnection mercuryDB = new SqlConnection())
            {
                mercuryDB.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mercury;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                try
                {
                    mercuryDB.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "delete from Fruits where FruitName = 'Conference'";
                        command.CommandType = CommandType.Text;
                        command.Connection = mercuryDB;
                        int rowsAffectd = command.ExecuteNonQuery();

                        if (rowsAffectd >= 1)
                            Console.WriteLine("En eller flera rader raderade!");
                        else
                            Console.WriteLine("Ingen rad raderad.");
                    }
                }
                catch (SqlException)
                {
                    Console.WriteLine("Problem med SQL");
                }
            }
        }

        private static void SafeDeleteDemo(string fruitName)
        {
            using (SqlConnection mercuryDB = new SqlConnection())
            {
                mercuryDB.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mercury;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                try
                {
                    mercuryDB.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = $"delete from Fruits where FruitName = @fruitName";

                        SqlParameter parameter = new SqlParameter();
                        parameter.Value = fruitName;
                        parameter.ParameterName = "@fruitName";
                        parameter.SqlDbType = SqlDbType.VarChar;
                        parameter.Size = 32;
                        parameter.Direction = ParameterDirection.Input;
                        command.Parameters.Add(parameter);

                        command.CommandType = CommandType.Text;
                        command.Connection = mercuryDB;
                        int rowsAffectd = command.ExecuteNonQuery();

                        if (rowsAffectd >= 1)
                            Console.WriteLine("En eller flera rader raderade!");
                        else
                            Console.WriteLine("Ingen rad raderad.");
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void UpdateDemo()
        {
            using (SqlConnection mercuryDB = new SqlConnection())
            {
                mercuryDB.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mercury;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                try
                {
                    mercuryDB.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.CommandText = "update Fruits set PricePerKg = 300.00 where FruitName = 'Conference'";
                        command.CommandType = CommandType.Text;
                        command.Connection = mercuryDB;
                        int rowsAffectd = command.ExecuteNonQuery();

                        if(rowsAffectd >= 1)
                            Console.WriteLine("En eller flera rader uppdaterade!");
                        else
                            Console.WriteLine("Ingen rad uppdaterad.");
                    }
                }
                catch (SqlException)
                {
                    Console.WriteLine("Problem med SQL");
                }
            }
        }

    private static void SqlDataReaderDemo()
    {
        List<Fruit> fruits = new List<Fruit>();

        using (SqlConnection mercuryDB = new SqlConnection())
        {
            mercuryDB.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mercury;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            try
            {
                mercuryDB.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "select * from Fruits";
                    command.CommandType = CommandType.Text;
                    command.Connection = mercuryDB;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Fruit aFruit = new Fruit();
                            aFruit.ID = (int)reader["ID"];
                            aFruit.FruitType = reader["FruitType"].ToString();
                            aFruit.FruitName = reader["FruitName"].ToString();
                            aFruit.PricePerKg = !reader.IsDBNull("PricePerKg") ? (decimal?)reader["PricePerKg"] : null;
                            fruits.Add(aFruit);
                        }
                    }
                }
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Tyvärr misslyckades anslutningen.");
            }
        }

        Console.WriteLine("----------------------");

        var resultSet = fruits
            .Where(f => f.PricePerKg < 25);

        foreach (Fruit fruit in resultSet)
        {
            Console.WriteLine(fruit);
        }
    }
}
}
