namespace StartUpTemplate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            // 1 2 3 4 1
            IList<int> input = Console
                                    .ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToList();

            IList<int> result = RemoveOddOccurrencesOfElements(input);
            Console.WriteLine(String.Join(" ", result));
        }

        private static IList<int> RemoveOddOccurrencesOfElements(IList<int> input)
        {
            IList<int> result = new List<int>();
            int sequence = 0;

            for (int i = 0; i < input.Count; i++)
            {

                for (int j = 0; j < input.Count; j++)
                {

                    if (input[i] == input[j])
                    {
                        sequence++;
                    }
                }
                if (sequence % 2 == 0)
                {
                    result.Add(input[i]);
                }

                sequence = 0;
            }



            return result;
        }
    }
}