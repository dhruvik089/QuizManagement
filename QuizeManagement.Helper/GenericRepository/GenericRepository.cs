using QuizeManagement.Helper.SpHelper;
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

                                quiz.Quiz_id = Convert.ToInt32(reader["Quiz_id"].ToString());

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

        public static CustomQuizModel GetQuizWithQuestionsAndOptions(int quizId)
        {
            var quizModelList = new CustomQuizModel();
            QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities();
            string connectionString = _context.Database.Connection.ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Get Quiz
                using (var cmd = new SqlCommand("GetQuizByQuizId", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@QuizId", quizId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            quizModelList.Quiz_id = (int)reader["Quiz_id"];
                            quizModelList.Title = reader["Title"].ToString();
                            quizModelList.Description = reader["Description"].ToString();
                        }
                    }
                }

                // Get Questions
                quizModelList.Questions = new List<CustomQuestionModel>();
                using (var cmd = new SqlCommand("GetQuestionsByQuizId", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@QuizId", quizId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var question = new CustomQuestionModel
                            {
                                Question_id = (int)reader["Question_id"],
                                Quiz_id = (int)reader["Quiz_id"],
                                Question_txt = reader["Question_txt"].ToString(),
                                Options = new List<CustomOptionModel>()
                            };

                            quizModelList.Questions.Add(question);
                        }
                    }
                }

                // Get Options
                foreach (var question in quizModelList.Questions)
                {
                    using (var cmd = new SqlCommand("GetOptionsByQuestionId", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@QuestionId", question.Question_id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var option = new CustomOptionModel
                                {
                                    option_id = (int)reader["option_id"],
                                    Question_id = (int)reader["Question_id"],
                                    Option_text = reader["Option_text"].ToString(),
                                    Is_correct = (bool)reader["Is_correct"]
                                };

                                question.Options.Add(option);
                            }
                        }
                    }
                }
            }

            return quizModelList;

        }

        public static void UpdateQuizQuestionAndOptions(CustomQuizModel quizModel)

        {
            QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities();

            string connectionString = _context.Database.Connection.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))

            {

                connection.Open();

                // Update Quiz

                //using (SqlCommand command = new SqlCommand("UpdateQuiz", connection))

                //{

                //    command.CommandType = CommandType.StoredProcedure;

                //    command.Parameters.AddWithValue("@QuizId", quizModel.Quiz_id);  

                //    command.Parameters.AddWithValue("@Title", quizModel.Title);  

                //    command.Parameters.AddWithValue("@Description", quizModel.Description);

                //    command.ExecuteNonQuery();

                //}

                // Update Questions and Options

                foreach (var question in quizModel.Questions)

                {

                    using (var cmd = new SqlCommand("UpdateQuestion", connection))

                    {

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@QuestionId", question.Question_id);

                        cmd.Parameters.AddWithValue("@QuestionTxt", question.Question_txt);

                        cmd.ExecuteNonQuery();

                    }

                    // Update each Option for the current Question

                    foreach (var option in question.Options)

                    {

                        using (var cmd = new SqlCommand("UpdateOption", connection))

                        {

                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@questionId", question.Question_id);

                            cmd.Parameters.AddWithValue("@OptionId", option.option_id);

                            cmd.Parameters.AddWithValue("@OptionText", option.Option_text);

                            cmd.Parameters.AddWithValue("@IsCorrect", option.Is_correct);

                            cmd.ExecuteNonQuery();

                        }

                    }

                }

            }

        }

        public static List<QuestionModel> getQuestionByQuizId(string commandText, Dictionary<string, object> parameters)
        {
            List<QuestionModel> QuestionModelList = new List<QuestionModel>();
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
                        foreach (var pera in parameters)
                        {
                            command.Parameters.AddWithValue(pera.Key, pera.Value);
                        }
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                QuestionModel quiz = new QuestionModel();

                                quiz.Quiz_id = Convert.ToInt32(reader["Quiz_id"].ToString());
                                quiz.Question_id = Convert.ToInt32(reader["Question_id"].ToString());

                                quiz.Question_txt = reader["Question_txt"].ToString();

                                QuestionModelList.Add(quiz);
                            }
                        }
                    }
                }
            }

            return QuestionModelList;
        }

        public static List<OptionsModel> GetOptionForQuestion(string commandText, Dictionary<string, object> parameters)
        {
            List<OptionsModel> QuestionModelList = new List<OptionsModel>();
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
                        foreach (var pera in parameters)
                        {
                            command.Parameters.AddWithValue(pera.Key, pera.Value);
                        }
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                OptionsModel _optionsModel = new OptionsModel();

                                _optionsModel.Question_id = Convert.ToInt32(reader["Question_id"].ToString());
                                _optionsModel.Option_id = Convert.ToInt32(reader["Option_id"].ToString());

                                _optionsModel.Option_text = reader["Option_text"].ToString();

                                QuestionModelList.Add(_optionsModel);
                            }
                        }
                    }
                }
            }

            return QuestionModelList;
        }

        public static int GetQuestionId(string commandText, Dictionary<string, object> parameters)
        {

            int questionID = 0;
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
                                    QuestionModel QuestionModel = new QuestionModel();

                                    questionID = Convert.ToInt32(reader["Question_id"].ToString());

                                }
                            }
                        }

                    }
                }
            }

            return questionID;
        }

        public static string GetQuestionById(string commandText, Dictionary<string, object> parameters)
        {
            string questionText = "";
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
                                    QuestionModel QuestionModel = new QuestionModel();

                                    questionText = reader["Question_txt"].ToString();

                                }
                            }
                        }

                    }
                }
            }

            return questionText;
        }

        public static int AddQuestionAnswerGiveByUser(string commandText, Dictionary<string, object> parameters)
        {
            int row_Affected = 0;
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
                        row_Affected = command.ExecuteNonQuery();
                    }
                }
            }
            return row_Affected;
        }

        public static int ResultOfQuizForUser(string commandText, Dictionary<string, object> parameters)
        {
            int CorrectAnswers = 0;
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

                                    CorrectAnswers = Convert.ToInt32(reader["correctAnswer"].ToString());

                                }
                            }
                        }
                    }
                }
            }
            return CorrectAnswers;
        }

        public static void DeleteQuizFromDB(string storedProcedureName, Dictionary<string, object> parameters)
        {
            QuizeManagement_0415Entities _context = new QuizeManagement_0415Entities();
            string connectionString = _context.Database.Connection.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (var parameter in parameters)
                    {
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        public static int UserAttemptOrNot(string commandText, Dictionary<string, object> parameters)
        {
            int Answers = 0;
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

                                    Answers = Convert.ToInt32(reader["countUserAttempt"].ToString());

                                }
                            }
                        }
                    }
                }
            }
            return Answers;
        }

    }
}
