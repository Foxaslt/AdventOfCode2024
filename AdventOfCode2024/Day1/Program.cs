using System.Collections.Generic;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            string[] rawData = File.ReadAllLines("RawData.txt");

            foreach (string line in rawData)
            {
                var items = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                list1.Add(int.Parse(items[0]));
                list2.Add(int.Parse(items[1]));
            }

            var order1 = list1.Order().ToArray();
            var order2 = list2.Order().ToArray();

            var sum = 0;
            for (int i = 0; i < Math.Min(list1.Count, list2.Count); i++)
            {
                sum += Math.Abs(order1[i] - order2[i]);
            }

            Console.WriteLine(sum);
            Console.WriteLine();

            var x = order2.CountBy(o => o);

            sum = 0;
            for (int i = 0; i < list1.Count; i++)
            {
                var match = x.FirstOrDefault(kvp => kvp.Key == list1[i]);
                if (!EqualityComparer<KeyValuePair<int, int>>.Default.Equals(match, default))
                    sum += list1[i] * match.Value;
            }

            Console.WriteLine(sum);
        }
    }
}
