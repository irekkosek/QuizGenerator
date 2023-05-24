using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace QuizGenerator.Model
{
    public class Quiz
    {
        public Quiz(int id,string title, List<Question> questions, int time)
        {
            Id = id;
            Title = title;
            Questions = questions;
            TimeSpan = time;
        }
        public Quiz() {
            List<Question> _questions = new List<Question>();
        }
        public Quiz(string name) { }

        private int _id;
        public int Id { get { return _id; } set { _id = value; } }

        private string _title;
        public string Title { get { return _title; } set { _title = value; } }

        private List<Question> _questions;
        public List<Question> Questions { get { return _questions; } set { _questions = value; } }

        private int _time_limit;
        public int TimeSpan { get { return _time_limit; } set { _time_limit = value; } }

        public override string ToString()
        {
            return $"{_title}";
        }
    }
}
