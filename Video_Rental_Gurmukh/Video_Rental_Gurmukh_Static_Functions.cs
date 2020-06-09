using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Rental_Gurmukh
{
    class Video_Rental_Gurmukh_Static_Functions
    {
        private static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["VideoRental_Gurmukh_Connection"].ToString();
        private static SqlConnection connection = null;
        private static SqlCommand command;
        private static SqlDataAdapter adapter;

        static Video_Rental_Gurmukh_Static_Functions()
        {
            connection = new SqlConnection(ConnectionString);
        }
        public static bool CheckConnection()
        {
            bool Result = false;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            Result = true;
            connection.Close();
            return Result;
        }
        public static void Add_Customer(string name, string phoneno, string address)
        {
            string Query = "INSERT INTO [Customers] VALUES (@Name, @Phone, @Address)";
            command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Phone", phoneno);
            command.Parameters.AddWithValue("@Address", address);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void Edit_Customer(string name, string phoneno, string address, string customerid)
        {
            string Query = "UPDATE [Customers] SET [Name] = @name, [Mobile] = @Phone, [Address] = @Address WHERE [ID] = @ID";
            command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Phone", phoneno);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@ID", customerid);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void Delete_Customer(string customerid)
        {
            string Query = "DELETE FROM [Customers] WHERE [ID] = @CustID";
            command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CustID", customerid);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static DataTable Find_All_Customers()
        {
            string Query = "SELECT * FROM [Customers]";
            command = new SqlCommand(Query, connection);
            DataTable table = new DataTable();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return table;
        }
        public static DataTable Find_Customer_By_Id(string customerid)
        {
            string Query = "SELECT * FROM [Customers] WHERE [ID] = @CustID";
            command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CustID", customerid);
            DataTable table = new DataTable();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return table;
        }
        public static DataTable Find_Best_Customers()
        {
            string Query = "SELECT *, ISNULL((SELECT COUNT(RMID) FROM RentedMovie WHERE CustIDFK = ID), 0) AS RentedMovie FROM Customer ORDER BY RentedMovie DESC";
            command = new SqlCommand(Query, connection);
            DataTable table = new DataTable();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return table;
        }
        public static void Add_Movie(string name, string points, int year, int copies, string releasedBy, int rental_cost)
        {
            string Query = "INSERT INTO [Videos] VALUES (@Name, @Points, @Year,@Copies , @ReleasedBy, @RentalCost)";
            command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Points", points);
            command.Parameters.AddWithValue("@Year", year);
            command.Parameters.AddWithValue("@Copies", copies);
            command.Parameters.AddWithValue("@ReleasedBy", releasedBy);
            command.Parameters.AddWithValue("@RentalCost", rental_cost);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void Edit_Movie(string name, string points, int year, int copies, string releasedBy, int rental_cost, string movieid)
        {
            string Query = "UPDATE [Videos] SET [Name] = @Name, [Points] = @Points, [Year] = @Year,  [Copies] = @Copies,[ReleasedBy]=@ReleasedBy,[RentalCost] = @Rental_Cost WHERE [ID] = @MovieID";
            command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Points", points);
            command.Parameters.AddWithValue("@Year", year);
            command.Parameters.AddWithValue("@Copies", copies);
            command.Parameters.AddWithValue("@Rental_Cost", rental_cost);
            command.Parameters.AddWithValue("@ReleasedBy", releasedBy);
            command.Parameters.AddWithValue("@MovieID", movieid);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void Delete_Movie(string movieid)
        {
            string Query = "DELETE FROM [Videos] WHERE [ID] = @MovieID";
            command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@MovieID", movieid);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static DataTable Find_All_Movies()
        {
            string Query = "SELECT * FROM [Videos]";
            command = new SqlCommand(Query, connection);
            DataTable table = new DataTable();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return table;
        }
        public static DataTable Find_Movie_By_Id(string movieid)
        {
            string Query = "SELECT * FROM [Videos] WHERE [ID] = @MovieID";
            command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@MovieID", movieid);
            DataTable table = new DataTable();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return table;
        }
        public static DataTable Get_Best_Selling_Movies()
        {
            string Query = "SELECT *, ISNULL((SELECT COUNT (RMID) FROM RentedMovie WHERE MovieIDFK = ID), 0) AS TimesRented FROM Videos ORDER BY TimesRented DESC";
            command = new SqlCommand(Query, connection);
            DataTable table = new DataTable();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return table;
        }
        public static void Add_Rental_Record(int movieid, int customerid, Nullable<System.DateTime> rentaldate)
        {
            string Query = "INSERT INTO [RentedMovie] (MovieIDFK, CustIDFK, DateRented) VALUES (@MovieIDFK, @CustIDFK, @DateRented)";
            command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@MovieIDFK", movieid);
            command.Parameters.AddWithValue("@CustIDFK", customerid);
            command.Parameters.AddWithValue("@DateRented", rentaldate);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void Update_Return_Record(Nullable<System.DateTime> returndate, string rmid)
        {
            string Query = "UPDATE [RentedMovie] SET [DateReturned] = @DateReturned WHERE [RMID] = @RMID";
            command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@DateReturned", returndate);
            command.Parameters.AddWithValue("@RMID", rmid);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static int Get_Available_Copies(int movieid)
        {
            string Query = "SELECT (SELECT Copies FROM Videos WHERE ID = @MovieID) - (SELECT ISNULL(COUNT(MovieIDFK), 0) FROM RentedMovie WHERE MovieIDFK = @MovieID AND DateReturned IS NULL)";
            command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@MovieID", movieid);
            DataTable table = new DataTable();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return Convert.ToInt32(table.Rows[0][0]);
        }
        public static DataTable Get_Pending_Rentals()
        {
            string Query = "SELECT RMID, Customers.Name, Customers.[Address], Videos.Name as VideoName, Videos.RentalCost, RentedMovie.DateRented, RentedMovie.DateReturned FROM RentedMovie INNER JOIN Videos ON RentedMovie.MovieIDFK = Videos.ID INNER JOIN Customers ON RentedMovie.CustIDFK = Customers.ID WHERE RentedMovie.DateReturned IS NULL";
            command = new SqlCommand(Query, connection);
            DataTable table = new DataTable();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return table;
        }
    }
}
