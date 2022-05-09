using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ConsoleTables;
using CRUD_Consola;


public class PeopleDB
{
    private readonly string connectionString =
        @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\estev\source\repos\CRUD Consola\CRUD Consola\Database1.mdf;Integrated Security=True";

    public List<People> GetAllPeople()
    {
        var listPeople = new List<People>();
        string query = "select * from people";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query,connection))
            {
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        People people = new People();
                        people.ID = reader.GetInt32(0);
                        people.Name = reader.GetString(1);
                        people.Age = reader.GetInt32(2);

                        listPeople.Add(people);
                    }
                    reader.Close();
                    connection.Close();

                    return listPeople;
                }
                catch
                {
                    Console.WriteLine("Ha ocurrido un Error!");
                    return listPeople;

                }
            } 
           
            
            
        }
    }

    public void Insert(string Name, int Age)
    {
        People x = new People();
        string query = "Insert into people(name,age) values(@name,@age)";

        using (SqlConnection connecton = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connecton);
            connecton.Open();
            command.Parameters.AddWithValue("@name", Name);
            command.Parameters.AddWithValue("@age", Age);
            command.ExecuteNonQuery();
            connecton.Close();

        }
    }

    public void Obtain(int id)
    {
        string query = "select id,name,age from people where id = @id";
        ConsoleTable table = new ConsoleTable("ID","Name","Age");

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query,connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    table.AddRow(reader[0],reader[1],reader[2]);
                }
                table.Write();
                reader.Close();
                connection.Close();
            }
            
        }
    }
}