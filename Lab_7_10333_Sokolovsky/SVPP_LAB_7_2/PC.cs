    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;


    namespace BD_Adapter
    {
        public class PC
        {
            static string connectionString;
            static SqlConnection connection;
            static SqlDataAdapter adapter;
            static DataTable PCTable = new DataTable();

            public int ID { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }
            public string Processor { get; set; }
            public decimal Price { get; set; }

            public static void newConnection()
            {
                connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
            }

            public static DataTable ViewAll()
            {
                newConnection();
                string sql = "SELECT * FROM PC";
                adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(PCTable);
                connection.Close();
                return PCTable;
            }

            public static void Update()
            {
                newConnection();
                // commandBuilder позволяет автоматически сгенерировать нужные SQL-выражения 
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(PCTable);
                connection.Close();

            }

            public string Find()
            {
                // для каждого варианта поиска требуется отдельный SELECT
                newConnection();
                DataTable personTable1 = new DataTable();
                string str = "";
                if (Brand != null)
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM PC WHERE (Brand=@brand)", connection);
                    command.Parameters.AddWithValue("brand", Brand);
                    adapter = new SqlDataAdapter(command);

                    adapter.Fill(personTable1);
                    foreach (DataRow row in personTable1.Rows)
                    {
                        // получаем все ячейки строки
                        var cells = row.ItemArray;
                        foreach (object cell in cells)
                            str += $"\t{cell}";
                        str += "\n";
                    }

                    return str;
                }
                else if (Model != null)
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM PC WHERE (Model=@model)", connection);
                    command.Parameters.AddWithValue("model", Model);
                    adapter = new SqlDataAdapter(command);

                    adapter.Fill(personTable1);
                    foreach (DataRow row in personTable1.Rows)
                    {
                        // получаем все ячейки строки
                        var cells = row.ItemArray;
                        foreach (object cell in cells)
                            str += $"\t{cell}";
                        str += "\n";
                    }

                    return str;
                }
                return null;

            }


            public override string ToString()
            {
                return $"{ID} Компьютер марки {Brand} модели {Model} с процессором {Processor}. Цена: {Price}";
            }
        }
    }
