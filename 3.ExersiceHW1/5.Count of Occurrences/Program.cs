namespace StartUpTemplate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            IList<int> input = Console
                                .ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToList();

            IList<int> result = SearchOccurrences(input);

        }
        
        private static IList<int> SearchOccurrences(IList<int> list)
        {
            int currentOccurrence = 0;
            int value = 0;

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        currentOccurrence++;
                        value = list[i];
                    }
                }
            }

            IList<int> result = new List<int>();    
            return result;
        }
    }
}