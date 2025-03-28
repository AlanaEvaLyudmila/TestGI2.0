using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGI
{
    class Question
    {
        string textQuestion;
        int rightAnswer;

        public Question(string text,int answer)
        {
            textQuestion = text;
            rightAnswer = answer;
        }
        public string ToString()
        {
            return textQuestion;
        }
        public bool checkAnswer(int userAnswer) 
        {
            return rightAnswer == userAnswer;
        }
    }
}
