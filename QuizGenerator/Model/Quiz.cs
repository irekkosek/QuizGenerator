using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace QuizGenerator.Model
{
    internal class Quiz
    {
        public Quiz() {
            List<Question> _questions = new List<Question>();
        }
        public Quiz(string name) { }

        private string _title;
        public string Title { get { return _title; } set { _title = value; } }

        private List<Question> _questions;
        public List<Question> Questions { get { return _questions; } set { _questions = value; } }

        private double _time_limit;
        public double TimeSpan { get { return _time_limit; } set { _time_limit = value; } }

        public override string ToString()
        {
            return $"{_title}";
        }
    }
}
