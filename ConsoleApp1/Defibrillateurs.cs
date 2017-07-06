using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Defibrillateurs
{
    class Deb
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Tel { get; set; }
        public decimal Long { get; set; }
        public decimal Lat { get; set; }
    }
    static void Main(string[] args)
    {
        string LON = Console.ReadLine();
        string LAT = Console.ReadLine();
        decimal longB = decimal.Parse(LON.Replace(",", "."));
        decimal latB = decimal.Parse(LAT.Replace(",", "."));

        int N = int.Parse(Console.ReadLine());
        decimal min = 0;
        Deb minDeb = null;
        for (int i = 0; i < N; i++)
        {
            string DEFIB = Console.ReadLine();
            var data = DEFIB.Split(';');
            var defib = new Deb()
            {
                Id = data[0],
                Nom = data[1],
                Adresse = data[2],
                Tel = data[3],
                Long = decimal.Parse(data[4].Replace(",", ".")),
                Lat = decimal.Parse(data[5].Replace(",", "."))
            };
            var x = (defib.Long - longB) * (decimal)Math.Cos((double)(defib.Lat + latB) / 2);
            var y = defib.Long - longB;
            var d = (decimal)Math.Sqrt(Math.Pow((double)x, 2) + Math.Pow((double)y, 2)) * 6371;
            Console.Error.WriteLine($"{defib.Nom} d = {d}");
            if (i == 0 || min > d)
            {
                min = d;
                minDeb = defib;
                Console.Error.WriteLine($"{minDeb.Long}");
            }
        }
        Console.Error.WriteLine("=========");
        Console.WriteLine(minDeb.Nom);
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
    }
}
