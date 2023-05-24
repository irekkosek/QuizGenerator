using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator.Model
{
    public class Question
    {
        public Question(int Question_ID, string title, List<Question.Answer> answers)
            {
                Id = Question_ID;
                Title = title;
                Answers = answers;
            }
        public struct Answer
        {
            public Answer(string content, bool is_correct)
            {

                this.is_correct = is_correct;
                this.content = content;
            }
            //private int id;
            private string content;
            private bool is_correct;

            public bool Is_correct
            {
                get => is_correct;
                set
                {
                    is_correct = value;
                }
            }
            public string Content { get => content; set => content = value; }
            //public int Id { get => id; set => id = value; }
        }
        public Question() { }
        public Question(string name) { }
        public int Id { get { return _id; } set { _id = value; } }
        public string Title { get { return _title; } set { _title = value; } }

        public List<Answer> Answers { get { return _answers; } set { _answers = value; } }

        private int _id;
        private string _title;
        private List<Answer> _answers;

        public override string ToString()
        {
            return $"{_title}";
        }

    }
}
