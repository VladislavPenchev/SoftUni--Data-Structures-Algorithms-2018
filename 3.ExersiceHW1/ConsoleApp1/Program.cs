namespace StartUpTemplate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<string> words = Console.ReadLine()
                                        .Split(' ')
                                        .ToList();

            Console.WriteLine(String.Join(" ",words.OrderBy(x => x)));

        }

        public void LongImplementation()
        {
            int a = 97;
            int z = 122;
            char currentChar;

            IList<string> input = Console
                .ReadLine()
                .Split()
                .ToList();

            char firstLetter;

            IList<char> listOfFirstLetter = new List<char>();

            //TODO zashtita

            foreach (var word in input)
            {
                for (int i = 0; i < word.Length; i++)
                {

                    //zashtita
                    firstLetter = word[0];
                    listOfFirstLetter.Add(firstLetter);
                    break;
                }
            }

            for (int i = 0; i < listOfFirstLetter.Count - 1; i++)
            {
                //zashtita ot prepulvane
                if (listOfFirstLetter[i] > listOfFirstLetter[i + 1])
                {
                    currentChar = listOfFirstLetter[i + 1];
                    listOfFirstLetter[i + 1] = listOfFirstLetter[i];
                    listOfFirstLetter[i] = currentChar;

                }
                else if (listOfFirstLetter[i] == listOfFirstLetter[i + 1])
                {
                }
            }
        }
    }
}

