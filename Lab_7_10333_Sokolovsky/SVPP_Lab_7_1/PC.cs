using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace BD
{
    internal class PC
    {
        static SqlConnection connection;
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Processor { get; set; }
        public decimal Price { get; set; }


        static PC()
        {
            var connstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connstring);
        }
        private static void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
            connection.Open();
        }

        public static IEnumerable<PC> getAllPersons()
        {
            openConnection();
            var SQLstr = "SELECT * FROM PC";
            SqlCommand getAllCommand = new SqlCommand(SQLstr, connection);
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var brand = reader.GetString(1);
                    var model = reader.GetString(2);
                    var processor = reader.GetString(3);
                    var price = reader.GetDecimal(4);
                    var person = new PC() { Id = id, Brand = brand, Model = model, Processor = processor, Price = price };
                    yield return person;
                }
            }
            connection.Close();
        }
        public void Insert()
        {
            openConnection();
            var SQLstr = "INSERT INTO PC (Brand, Model, Processor, Price) VALUES (@brand, @model, @processor, @price)";
            SqlCommand insertCommand = new SqlCommand(SQLstr, connection);
            insertCommand.Parameters.AddRange(new SqlParameter[]
            {
                new SqlParameter("brand", Brand),
                new SqlParameter("model", Model),
                new SqlParameter("processor", Processor),
                new SqlParameter("price", Price)
            });
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void Delete(int id)
        {
            openConnection();
            var commandString = "DELETE FROM PC WHERE(Id=@id)";
            SqlCommand deleteCommand = new SqlCommand(commandString, connection);
            deleteCommand.Parameters.AddWithValue("id", id);
            deleteCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static PC Find(string name)
        {
            foreach (var person in getAllPersons())
            {
                if (person.Brand == name)
                    return person;
            }
            return null;
        }

        public void Update()
        {
            openConnection();
            var commandString = "UPDATE PC SET Brand=@brand, Model=@model, Processor=@processor, Price=@price WHERE(Id=@id)";
            SqlCommand updateCommand = new SqlCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SqlParameter[] {
                             new SqlParameter("brand", Brand),
                             new SqlParameter("model", Model),
                             new SqlParameter("processor", Processor),
                             new SqlParameter("price", Price),
                             new SqlParameter("id", Id),});
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }


        public override string ToString()
        {
            return $"№ {Id} Марка: {Brand}, Модель: {Model}, Процессор:{Processor}, Частота процессора: {Price:0.00}";
        }
    }
}
