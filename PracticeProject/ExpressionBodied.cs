using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeProject
{
    class ExpressionBodied
    {

        private readonly int _health;

        private readonly int _test;
        public ExpressionBodied(int health,int test) => (_health,_test) =( health >= 0 ? health : throw new ArgumentOutOfRangeException() ,_test=test) ;

        public int Add(int x, int y) => x + y ;


        public void m1()
        {
            string test = "saitej kuralla";
            int count = test.CountWords();
        }
    }


    public static class WordCount
    {

        public static int CountWords(this string value)
        {
            return value.Length;
        }
    }
}
