namespace StartUpTemplate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int sum = 0;
            double avarage = 0;

            var input = Console
            .ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();


            
            if (input != null)
            {
                for (int i = 0; i < input.Count; i++)
                {
                    sum += input[i];
                }

                avarage = (double)sum / (double)input.Count;
                avarage = Math.Round(avarage, 2);

                if (avarage % 1 == 0)
                {
                    Console.WriteLine($"Sum={sum}; Average={avarage}.00");
                }
                else
                {

                }
            }
            else
            {
                Console.WriteLine($"Sum=0; Average=0.00");
            }



        }
    }
}
