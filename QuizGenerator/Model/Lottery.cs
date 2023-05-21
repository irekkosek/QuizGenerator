using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator.Model
{
    class Lottery
    {
        private int maxNumber;
        private int numberOfSelection;


        public Lottery(int maxNumber = 49, int numberOfSelection = 6)
        {
            this.maxNumber = maxNumber;
            this.numberOfSelection = numberOfSelection;
        }

        public int[] LotteryRandom()
        {
            int current;
            Random random = new Random(DateTime.Now.Millisecond);
            var result = new int[numberOfSelection];
            List<int> ball = new List<int>();
            for (int i = 0; i < maxNumber; i++)
                ball.Add(i + 1);

            for (int i = 0; i < numberOfSelection; i++)
            {
                current = random.Next(1, maxNumber - i);
                result[i] = ball[current];
                ball.Remove(result[i]);
            }


            return result;
        }


    }
}
