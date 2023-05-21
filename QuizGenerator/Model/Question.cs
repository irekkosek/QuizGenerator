﻿using System;
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
           public string content;
           public bool is_correct;

        }
        //public Question() { }
        //public Question(string name) { }
        public int Id { get { return _id; } set { _id = value; } }
        public string Title { get { return _title; } set { _title = value; } }

        public List<Answer> Answers { get { return _answers; } set { _answers = value; } }

        private int _id;
        private string _title;
        private List<Answer> _answers;

        public override string ToString()
        {
            return $"{_title} #{_id}";
        }

    }
}
