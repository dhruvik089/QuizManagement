using QuizeManagement.Models.DbContext;
using QuizeManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuizeManagement.Helper.GenericRepository
{
    public class GenericRepository
    {
        public static DataTable GetSingleDataTable(string commandText, Dictionary<string, object> parameters)
        {
            DataTable _dataTable = new DataTable();

            using (QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities())
            {
                string connectionString = _context.Database.Connection.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 120;

                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                            }
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(_dataTable);
                        }
                    }
                }
            }

            return _dataTable;
        }

        public static bool IsEmailExist(string commandText, Dictionary<string, object> parameters)

        {

            DataTable dataTable = new DataTable();

            bool isExist = false;

            using (QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities())

            {

                string connectionString = _context.Database.Connection.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))

                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(commandText, connection))

                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.CommandTimeout = 120;

                        if (parameters != null)

                        {

                            foreach (var parameter in parameters)

                            {

                                command.Parameters.AddWithValue(parameter.Key, parameter.Value);

                            }

                        }

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int EmailExistsInt))

                        {

                            isExist = EmailExistsInt == 1;

                        }

                    }

                }

            }

            return isExist;

        }

        public static string getUserName(string commandText, Dictionary<string, object> parameters)

        {

            string UserName = null;

            using (QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities())

            {

                string connectionString = _context.Database.Connection.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))

                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(commandText, connection))

                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.CommandTimeout = 120;

                        if (parameters != null)

                        {
                            foreach (var parameter in parameters)

                            {
                                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                            }

                        }

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int Username))

                        {
                            UserName = Username.ToString();
                        }

                    }

                }

            }

            return UserName;
        }

        public static RegisterModel CheckingUserIsValidOrNotLogin(string commandText, Dictionary<string, object> parameters)

        {

            RegisterModel result = new RegisterModel();

            using (QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities())

            {

                string connectionString = _context.Database.Connection.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))

                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(commandText, connection))

                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.CommandTimeout = 120;

                        if (parameters != null)

                        {

                            foreach (var parameter in parameters)

                            {

                                command.Parameters.AddWithValue(parameter.Key, parameter.Value);

                            }

                        }

                        using (SqlDataReader reader = command.ExecuteReader())

                        {

                            // Check if there are any rows returned

                            if (reader.HasRows)

                            {

                                // Read each row

                                while (reader.Read())

                                {

                                    string username = reader["Username"].ToString();
                                    string password = reader["Password_hash"].ToString();

                                    string email = reader["Email"].ToString();

                                    int user_id = Convert.ToInt32(reader["User_id"].ToString());

                                    var user = new { Username = username, Password_hash = password, Email = email, User_Id = user_id };



                                    result.Userid = user_id;
                                    result.Password = password;
                                    result.Username = username;

                                    result.Email = email;

                                }

                            }

                        }

                    }

                }

            }

            return result;

        }

        public static AdminModel CheckingAdminLogin(string commandText, Dictionary<string, object> parameters)

        {

            AdminModel result = new AdminModel();

            using (QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities())

            {

                string connectionString = _context.Database.Connection.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))

                {

                    connection.Open();

                    using (SqlCommand command = new SqlCommand(commandText, connection))

                    {

                        command.CommandType = CommandType.StoredProcedure;

                        command.CommandTimeout = 120;

                        if (parameters != null)

                        {

                            foreach (var parameter in parameters)

                            {

                                command.Parameters.AddWithValue(parameter.Key, parameter.Value);

                            }

                        }

                        using (SqlDataReader reader = command.ExecuteReader())

                        {

                            if (reader.HasRows)

                            {
                                while (reader.Read())

                                {
                                    string username = reader["Username"].ToString();
                                    string password = reader["Password"].ToString();
                                    string email = reader["Email"].ToString();
                                    int Admin_id = Convert.ToInt32(reader["Admin_id"].ToString());

                                    result.Admin_id = Admin_id;
                                    result.Password = password;
                                    result.Username = username;
                                    result.Email = email;

                                }

                            }

                        }

                    }

                }

            }

            return result;

        }

        public static UserModel GetUserDetails(string spName, Dictionary<string, object> perameter)
        {
            UserModel _usermodel = new UserModel();

            using (QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities())
            {
                string connectionString = _context.Database.Connection.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(spName, connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    if (perameter != null)
                    {
                        foreach (var i in perameter)
                        {
                            sqlCommand.Parameters.AddWithValue(i.Key, i.Value);
                        }
                    }

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string username = reader["Username"].ToString();
                                string email = reader["Email"].ToString();
                                int User_id = Convert.ToInt32(reader["User_id"].ToString());

                                _usermodel.User_id = User_id;
                                _usermodel.Username = username;
                                _usermodel.Email = email;
                            }
                        }
                    }

                }
            }


            return _usermodel;
        }

        public static bool userModel(string spName, Dictionary<string, object> perameter)
        {
            UserModel _usermodel = new UserModel();

            using (QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities())
            {
                string connectionString = _context.Database.Connection.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(spName, connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    if (perameter != null)
                    {
                        foreach (var i in perameter)
                        {
                            sqlCommand.Parameters.AddWithValue(i.Key, i.Value);
                        }
                    }

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string username = reader["Username"].ToString();
                                string email = reader["Email"].ToString();

                                _usermodel.Username = username;
                                _usermodel.Email = email;
                            }

                            return true;
                        }
                    }

                }
            }


            return false;
        }

        public static UserModel GetUserDetailsById(string spName, Dictionary<string, object> perameter)
        {
            UserModel _usermodel = new UserModel();

            using (QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities())
            {
                string connectionString = _context.Database.Connection.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(spName, connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    if (perameter != null)
                    {
                        foreach (var i in perameter)
                        {
                            sqlCommand.Parameters.AddWithValue(i.Key, i.Value);
                        }
                    }

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string username = reader["Username"].ToString();
                                string email = reader["Email"].ToString();
                                int User_id = Convert.ToInt32(reader["User_id"].ToString());

                                _usermodel.User_id = User_id;
                                _usermodel.Username = username;
                                _usermodel.Email = email;
                            }
                        }
                    }

                }
            }


            return _usermodel;
        }

        public static QuizzesModel GenerateQuiz(string commandText, Dictionary<string, object> parameters)

        {

            QuizzesModel _QuizzesModel = new QuizzesModel();

            QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities();

            string connectionString = _context.Database.Connection.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))

            {

                connection.Open();

                using (SqlCommand command = new SqlCommand(commandText, connection))

                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.CommandTimeout = 120;

                    if (parameters != null)

                    {

                        foreach (var parameter in parameters)

                        {

                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);

                        }

                    }

                    using (SqlDataReader reader = command.ExecuteReader())

                    {

                        if (reader.HasRows)

                        {

                            while (reader.Read())

                            {

                                string title = reader["Title"].ToString();

                                string description = reader["Description"].ToString();


                                _QuizzesModel.Title = title;

                                _QuizzesModel.Description = description;

                            }

                        }

                    }

                }

            }

            return _QuizzesModel;

        }

        public static List<QuizzesModel> GetQuizList(string commandText, Dictionary<string, object> parameters)

        {

            List<QuizzesModel> quizList = new List<QuizzesModel>();
            QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities();

            string connectionString = _context.Database.Connection.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))

            {

                connection.Open();

                using (SqlCommand command = new SqlCommand(commandText, connection))

                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.CommandTimeout = 120;

                    if (parameters != null)

                    {

                        foreach (var parameter in parameters)

                        {

                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);

                        }

                    }

                    using (SqlDataReader reader = command.ExecuteReader())

                    {

                        if (reader.HasRows)

                        {

                            while (reader.Read())

                            {

                                QuizzesModel quiz = new QuizzesModel();

                                quiz.Quiz_id =Convert.ToInt32(reader["Quiz_id"].ToString());

                                quiz.Title = reader["Title"].ToString();

                                quiz.Description = reader["Description"].ToString();

                                quizList.Add(quiz);

                            }

                        }

                    }

                }

            }

            return quizList;

        }

        public static void AddQuestion(string commandText, Dictionary<string, object> parameters)
        {
            List<QuizzesModel> _QuizzeModelList = new List<QuizzesModel>();
            using (QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities())
            {
                string connectionString = _context.Database.Connection.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 120;

                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                            }
                        }
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
    