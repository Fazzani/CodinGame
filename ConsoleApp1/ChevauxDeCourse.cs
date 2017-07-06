using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class ChevauxDeCourse
{
    static void Main(string[] args)
    {
        int res = Int32.MaxValue;
        int N = int.Parse(Console.ReadLine());
        var slist = new List<int>();

        for (int i = 0; i < N; i++)
        {
            int pi = int.Parse(Console.ReadLine());
            slist.Add(pi);
        }

        var ordredList = slist.OrderByDescending(x => x).ToList();
        for (int i = 0; i < ordredList.Count() - 2; i++)
        {
            var dist = ordredList[i] - ordredList[i + 1];
            if (dist < res)
                res = dist;
        }
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(res);
        Console.ReadKey();
        
    }

    private static void Sol2()
    {
        int res = Int32.MaxValue;
        int N = int.Parse(Console.ReadLine());
        var slist = new SortedList<int, int>();

        for (int i = 0; i < N; i++)
        {
            int pi = int.Parse(Console.ReadLine());

            if (slist.ContainsKey(pi))
            {
                res = 0;
                continue;
            }
            else
                slist.Add(pi, pi);

            if (i == 0 || res == 0)
                continue;
            var index = slist.IndexOfKey(pi);

            if (index > 0 && res != 0 && pi - slist.Values[index - 1] < res)
                res = pi - slist.Values[index - 1];
            if (index < (slist.Count - 1) && res != 0 && slist.Count > 1 && slist.Values[index + 1] > res)
                res = slist.Values[index + 1] - pi;
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(res);
        Console.ReadKey();
    }
}