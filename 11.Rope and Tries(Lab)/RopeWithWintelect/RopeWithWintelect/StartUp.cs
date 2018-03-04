namespace RopeWithWintelect
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using Wintellect.PowerCollections;
    public class StartUp
    {
        public static void Main()
        {
            //int iterations = 1000000;
            //Console.WriteLine($"Interations: {iterations}");
            //BigList<string> rope = new BigList<string>();


            //Stopwatch timer = new Stopwatch();
            //timer.Start();
            //for (int i = 0; i < iterations; i++)
            //{
            //    rope.Insert(0, "str");
            //}
            //Console.WriteLine($"Rope prepend time elapsed: {timer.ElapsedMilliseconds}");

            //StringBuilder builder = new StringBuilder();

            //timer = new Stopwatch();
            //timer.Start();
            //for (int i = 0; i < iterations; i++)
            //{
            //    builder.Insert(0, "str");
            //}
            //Console.WriteLine($"builder prepend time elapsed: {timer.ElapsedMilliseconds}");

            StringBuilder builder = new StringBuilder();

            var result = builder.Append("Gosho vv gosho");

            Console.WriteLine(result);

            var res = builder.Insert(1, "OKI");
            Console.WriteLine(res);

        }
    }
}
