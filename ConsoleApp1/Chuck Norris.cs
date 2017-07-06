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
class ChuckNorris
{
    private const char SEP = '?';

    static void Main(string[] args)
    {
        string MESSAGE = Console.ReadLine();
        var MessageBit = string.Join("", MESSAGE.Select(x => Convert.ToString(x, 2).PadLeft(7, '0')));

        string res = string.Empty;
        var lastChar = 'x';
        foreach (var c in MessageBit)
        {
            if (lastChar != c)
            {
                if (c == '1')
                    res += " 0 0";
                else if (c == '0')
                    res += " 00 0";
                lastChar = c;
            }
            else
                res += "0";
        }

        Console.WriteLine(res.Trim());
        Console.ReadKey();
    }
}