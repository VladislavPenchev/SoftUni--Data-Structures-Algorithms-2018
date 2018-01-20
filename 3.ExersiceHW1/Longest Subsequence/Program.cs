namespace StartUpTemplate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            //input 12 2 7 4 3 3 8
            // 3 3 3 2 2 2 
            //4 4 3 3 3 2 2 2

                        
            IList<int> input = Console
                                    .ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToList();

            if (input == null)
            {
                return;
            }

            //kak se naricha tova prisvoqvane
            IList<int> result = SearchLongesSubSequence(input);

            Console.WriteLine(string.Join(" ",result));

        }

        private static IList<int> SearchLongesSubSequence(IList<int> list)
        {
            int sequence = 1;
            int maxSequence = 1;
            int digitSequence = 0;

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (i + 1 >= list.Count)
                {
                    continue;
                }

                if (list[i] == list[i + 1])
                {
                    sequence++;
                    if (sequence > maxSequence)
                    {
                        maxSequence = sequence;
                        digitSequence = list[i];

                    }
                }
                else
                {
                    sequence = 1;
                }
                
            }

            IList<int> result = new List<int>();
            for (int i = 0; i < maxSequence; i++)
            {
                result.Add(digitSequence);
            }

            return result;
        }
        
    }
}
