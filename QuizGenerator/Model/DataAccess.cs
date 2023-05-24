using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace QuizGenerator.Model
{

    public class DataAccess
    {
        public BindingList<Quiz> LoadData()
        {
            List<Question.Answer> _answers = new List<Question.Answer>();
            List<Question> _questions = new List<Question>();
            BindingList<Quiz> _quizzes = new BindingList<Quiz>();
            //using (var conn = new SQLiteConnection("Data Source=QuizSolverDB.db"))
            using (var conn = new SQLiteConnection(@"Data Source=QuizSolver.db;Version=3"))

            {
                conn.Open();
                var commandAns = conn.CreateCommand();
                commandAns.CommandText = "SELECT Answers.ID, Answers.content, Answers.is_correct, Answers.Question_ID , Questions.quiz_id  FROM Answers\r\nLEFT JOIN Questions ON Answers.question_id = Questions.ID";
                var commandQuest = conn.CreateCommand();
                commandQuest.CommandText = "SELECT * FROM Questions ";
                var commandQuiz = conn.CreateCommand();
                commandQuiz.CommandText = "SELECT * FROM Quizzes ";

                using (var readerQuiz = commandQuiz.ExecuteReader())
                {
                    while (readerQuiz.Read())
                    {
                        int QuizID = readerQuiz.GetInt16(0);

                        using (var readerQuest = commandQuest.ExecuteReader())
                        {
                            _questions.Clear();
                            while (readerQuest.Read())
                            {
                                int QuestID = readerQuest.GetInt16(0);

                                if (readerQuest.GetInt16(2) == QuizID)
                                {
                                    using (var readerAns = commandAns.ExecuteReader())
                                    {
                                        _answers.Clear();
                                        while (readerAns.Read())
                                        {
                                            if (readerAns.GetInt16(3) == QuestID && readerAns.GetInt16(4) == QuizID)
                                            {
                                                _answers.Add(new Question.Answer(Encode.Base64Decode(readerAns.GetString(1)), readerAns.GetBoolean(2)));
                                            }
                                        }
                                    }
                                    _questions.Add(new Question(readerQuest.GetInt16(0), Encode.Base64Decode(readerQuest.GetString(1)), new List<Question.Answer>(_answers)));
                                }

                            }
                        }
                        _quizzes.Add(new Quiz(QuizID, Encode.Base64Decode(readerQuiz.GetString(1)), new List<Question>(_questions), readerQuiz.GetInt16(2)));
                    }
                }
                conn.Close();
                return _quizzes;
            }
        }
    }
    // JEŻELI JESZCZE TEGO NIE ZROBIONO TO NALEŻY DODAĆ ENTITY FRAMEWORK W NUGET
    // żeby poprawnie obsługiwać przechowywanie obiektów w SQLite
    //static class DataAccess
    //{
    //    static SQLiteConnection conn = new SQLiteConnection(@"Data Source=QuizSolver.db;Version=3");

    //    private static void ReadData(SQLiteConnection conn)
    //    {
    //        SQLiteDataReader reader;
    //        SQLiteCommand command;

    //        command = conn.CreateCommand();
    //        command.CommandText = "SELECT * FROM Answers JOIN Questions on Answers.question_id = Questions.id JOIN Quizzes ON Questions.Quiz_ID = Quizzes.ID;";
    //        reader = command.ExecuteReader();

    //        while (reader.Read())
    //        {
    //            Quiz readquiz = new Quiz();
    //            int answer_id = (int)reader.GetInt32(0);
    //            string Content = (string)reader["Content"];
    //            bool Is_Correct = (bool)reader["Is_Correct"];
    //            int Question_ID = (int)reader.GetInt32(4);
    //            string QuestionTitle = (string)reader["Title"];
    //            int Quiz_ID = (int)reader.GetInt32(7);
    //            string  QuizTitle= (string)reader["title"];
    //            int timelimit = (int)reader["timelimit"];

    //             //kolejne atyrbuty
    //            Console.WriteLine($"{ answer_id} {Content } { Is_Correct } { Question_ID } { QuestionTitle } { Quiz_ID } { QuizTitle } { timelimit }");
    //        }


    //    }

    //    public static void ReadData()
    //    {
    //        try
    //        {
    //            conn.Open();
    //            ReadData(conn);
    //            conn.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
    //    }
    //}
}
