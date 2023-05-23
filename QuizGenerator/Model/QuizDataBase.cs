using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator.Model
{
    internal class QuizDataBase
    {
        //public List<Quiz> LoadData()
        //{
        //    var _quizList = new List<Quiz>();
        //    using (var connection = new SQLiteConnection("Data Source=QuizSolver.db"))
        //    {
        //        connection.Open();

        //        var command = connection.CreateCommand();
        //        command.CommandText = "Select id_quiz, name from quizTable";

        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                _quizList.Add(new Quiz() { Title=reader.get})
        //            }
        //        }
        //    }
        //}
    }
}
