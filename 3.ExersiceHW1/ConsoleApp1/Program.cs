namespace StartUpTemplate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int a = 97;
            int z = 122;

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

            for (int i = 0; i < listOfFirstLetter.Count; i++)
            {
                if (listOfFirstLetter[i] > listOfFirstLetter[i + 1])
                {
                    
                }
                else if(listOfFirstLetter[i] < listOfFirstLetter[i+1])
                {

                }
            }


        }
    }
}

