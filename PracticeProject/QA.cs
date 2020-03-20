using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeProject
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public QuestionAndAnswers QA { get; set; }

    }

    public class QuestionAndAnswers
    {
        public Dictionary<string, string> QuestionandAnswer { get; set; }
    }



}
