using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator.Model
{

    // JEŻELI JESZCZE TEGO NIE ZROBIONO TO NALEŻY DODAĆ ENTITY FRAMEWORK W NUGET
    // żeby poprawnie obsługiwać przechowywanie obiektów w SQLite
    static class DataAccess
    {
        static SQLiteConnection conn = new SQLiteConnection(@"Data Source=QuizSolver.db;Version=3");

        private static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader reader;
            SQLiteCommand command;

            command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Answers JOIN Questions on Answers.question_id = Questions.id JOIN Quizzes ON Questions.Quiz_ID = Quizzes.ID;";
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Quiz readquiz = new Quiz();
                int answer_id = (int)reader.GetInt32(0);
                string Content = (string)reader["Content"];
                bool Is_Correct = (bool)reader["Is_Correct"];
                Int64 Question_ID = (int)reader.GetInt32(4);
                string QuestionTitle = (string)reader["Title"];
                int Quiz_ID = (int)reader.GetInt32(7);
                string  QuizTitle= (string)reader["title"];
                int timelimit = (int)reader["timelimit"];

                 //kolejne atyrbuty
                Console.WriteLine($"{ answer_id} {Content } { Is_Correct } { Question_ID } { QuestionTitle } { Quiz_ID } { QuizTitle } { timelimit }");
            }


        }

        public static void ReadData()
        {
            try
            {
                conn.Open();
                ReadData(conn);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
