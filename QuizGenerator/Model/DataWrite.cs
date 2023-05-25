using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator.Model
{
    internal class DataWrite
    {
        private string connectionString = @"Data Source=QuizSolver.db;Version=3";
        public void ClearDBBeforeWrite()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Answers;DELETE FROM Questions;DELETE FROM Quizzes;";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void InsertQuestion(int Question_ID, string QuestionTitle, int Quiz_ID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Questions (ID, Title, Quiz_ID) VALUES (@Question_ID, @QuestionTitle, @Quiz_ID);";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Question_ID", Question_ID);
                    command.Parameters.AddWithValue("@QuestionTitle", Encryption.Base64Encode(QuestionTitle));
                    command.Parameters.AddWithValue("@Quiz_ID", Quiz_ID);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void InsertQuiz(int Quiz_ID, string QuizTitle, int timelimit)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Quizzes (ID, title, timelimit) VALUES (@Quiz_ID, @QuizTitle, @timeLimit);";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Quiz_ID", Quiz_ID);
                    command.Parameters.AddWithValue("@QuizTitle", Encryption.Base64Encode(QuizTitle));
                    command.Parameters.AddWithValue("@timeLimit", timelimit);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void InsertAnswers(int Answer_ID, string Content, bool is_Correct, int Question_ID)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Answers (ID, Content, Is_Correct, Question_ID) VALUES (@Answer_ID, @Content, @is_Correct, @Question_ID);";

                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Answer_ID", Answer_ID);
                    command.Parameters.AddWithValue("@Content", Encryption.Base64Encode(Content));
                    command.Parameters.AddWithValue("@is_Correct", is_Correct);
                    command.Parameters.AddWithValue("@Question_ID", Question_ID);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

    }
}
