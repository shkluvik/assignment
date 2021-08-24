using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PandellAssignment1
{
    class Assignment
    {
        /// <summary>
        /// Print flag 
        /// Disables in Project Properties
        /// </summary>
        static bool Print;

        static async Task Main(string[] args)
        {
            bool.TryParse(args[0], out Print);
            do
            {
                Console.Write("Enter Number: ");
                string read = Console.ReadLine();
                if (!int.TryParse(read, out int max)) break;
                await Task.Run(() => Run(max));
            } while (true);

        }

        private static List<int> Randomize(int max)
        {
            Random rand = new Random();
            List<int> List = Enumerable.Range(1, max).ToList();
            int j, temp;
            for (int i = 0; i < max; i++)
            {
                j = rand.Next(0, i);
                temp = List[i];
                List[i] = List[j];
                List[j] = temp;
            }
            return List;
        }

        public static void Run(int max)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<int> List = Randomize(max);
            stopwatch.Stop();
            long AlgorithmTime = stopwatch.ElapsedMilliseconds;
            if (Print)
            {
                stopwatch.Restart();
                foreach (int number in List)
                {
                    Console.Write($"{number}\t");
                }
                Console.WriteLine();
                stopwatch.Stop();
                Console.WriteLine($"Display Time: {stopwatch.ElapsedMilliseconds} ms");
            }
            Console.WriteLine($"Algorithm Time: {AlgorithmTime} ms");
        }

    }
}
