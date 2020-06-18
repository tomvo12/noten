using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace noten
{
    class Program
    {
        static void Main(string[] args)
        {
            var summen = new Dictionary<string, double>();
            var classCount = new Dictionary<string, int>();
            var count = 0;
            var summe = .0;

            using (var fs = File.OpenText("noten.dat"))
            {
                while (!fs.EndOfStream)
                {
                    var data = fs.ReadLine();
                    var spalten = data.Split(' ');
                    var klasse = spalten[0];
                    var note = double.Parse(spalten[1]);
                    summe += note;
                    if (summen.Keys.Contains(klasse))
                    {
                        classCount[klasse]++;
                        summen[klasse] += note;
                    }
                    else
                    {
                        summen.Add(klasse, note);
                        classCount.Add(klasse, 1);
                    }
                    count++;
                }
            }

            foreach (var klasse in summen.Keys)
            {
                Console.WriteLine($"Klasse {klasse}: {summen[klasse] / classCount[klasse]:N2}");
            }

            Console.WriteLine($"Schnitt Liste: {summe / count:N2}");
        }
    }
}
