using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator.Model
{
    internal class Question
    {
        public struct Answer
        {
            string content;
            bool is_correct;

        }
        //public Question() { }
        //public Question(string name) { }
        public int Id { get; set; }
        public string Title { get; set; }

        public Answer[] Answers { get; set; }

        private string _id;
        private string _title;
        private Answer[] _answers;

        public override string ToString()
        {
            return $"{_title} #{_id}";
        }

    }
}
