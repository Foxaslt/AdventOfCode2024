
using System.Security.Cryptography;

namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int[]> list = new List<int[]>();
            string[] rawData = File.ReadAllLines("RawData.txt");
            foreach (string data in rawData)
            {
                var items = data.Split(' ');
                 list.Add(items.Select(x => int.Parse(x)).ToArray());
            }

            int count = 0;
            foreach (var item in list)
            {
                if (IsSafe(item))
                    count++;
            }
            Console.WriteLine(count);
            Console.WriteLine();
        }

        static bool IsSafe(int[] line)
        {
            // Determine if the line is strictly increasing or decreasing
            bool isIncreasing = true, isDecreasing = true;

            for (int i = 1; i < line.Length; i++)
            {
                int diff = line[i] - line[i - 1];

                // Check if adjacent difference is within [1, 3]
                if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
                    return false;

                // Check increasing or decreasing
                if (diff < 0) isIncreasing = false;
                if (diff > 0) isDecreasing = false;
            }

            // Line must be either strictly increasing or strictly decreasing
            return isIncreasing || isDecreasing;
        }

        //private static bool IsSafe(int[] item)
        //{
        //    bool safe = true;
        //    var increasing = item[0].CompareTo(item[1]) != 0;
        //    for (int i = 1; i < item.Count(); i++)
        //    {
        //        var diff = Math.Abs(item[i] - item[i + 1]);
        //        if ((diff < 1 || diff > 3) && (item[i].CompareTo(item[i + 1]) != 0) == increasing)
        //        {
        //            safe = false;
        //            break;
        //        }
        //    }
        //    return safe;
        //}
    }
}
