using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUp
{
    class Mainn
    {
        static void Main(string[] args)
        {
            string expression = "1 +((2 + 3) * 4 /(3 + 1)) * 5";

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                char current = expression[i];

                if(current == '(')
                {
                    stack.Push(i);
                }
                else if(current == ')')
                {
                    int prev = stack.Pop();
                    int length = i - prev + 1;
                    string exp = expression.Substring(prev, length);

                    Console.WriteLine(exp);
                }
            }
        }
    }
}
