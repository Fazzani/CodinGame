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
class ASCII
{
    private const char SEP = '?';

    static void Main(string[] args)
    {
        var input = File.ReadAllLines(@"ASCII2_Input.txt");

        int L = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        Console.Error.WriteLine($"L : {L} H : {H}");
        string T = Console.ReadLine();
        Console.Error.WriteLine(T);
        var ASCIIValues = Encoding.ASCII.GetBytes(T.ToUpperInvariant());
        var unknown = Encoding.ASCII.GetBytes("?")[0];
        var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";
        var ASCIIValuesAZ = Encoding.ASCII.GetBytes(alphabet);
        var d = new Dictionary<byte, string>();

        for (int i = 0; i < H; i++)
        {
#if DEBUG

            string ROW = input[i];
#else
            string ROW = Console.ReadLine();
#endif
            Console.Error.WriteLine($"ROW : {ROW}");
            for (int j = 0; j < ASCIIValuesAZ.Length; j++)
            {
                var lowerByte = Encoding.ASCII.GetBytes(Convert.ToChar(ASCIIValuesAZ[j]).ToString().ToLowerInvariant())[0];
                if (d.ContainsKey(ASCIIValuesAZ[j]))
                {
                    d[ASCIIValuesAZ[j]] += string.Join(string.Empty, ROW.Skip(L * j).Take(L)) + SEP;
                    if (unknown != ASCIIValuesAZ[j])
                        d[lowerByte] += string.Join(string.Empty, ROW.Skip(L * j).Take(L)) + SEP;
                }
                else
                {
                    d[ASCIIValuesAZ[j]] = string.Join(string.Empty, ROW.Skip(L * j).Take(L)) + SEP;
                    if (unknown != ASCIIValuesAZ[j])
                        d[lowerByte] = string.Join(string.Empty, ROW.Skip(L * j).Take(L)) + SEP;
                }
            }
        }

        for (int i = 0; i < H; i++)
        {
            foreach (var ascii in ASCIIValues)
            {
                if (d.ContainsKey(ascii))
                    Console.Write(d[ascii].Split(SEP)[i]);
                else
                    Console.Write(d[unknown].Split(SEP)[i]);
            }
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}