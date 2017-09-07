using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shennon
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Fano fano = new Fano();
            int count= fano.Sort(s);
            Dictionary<char, string> outputalpha= fano.Rec(0, count+1);
            foreach(KeyValuePair<char,string> kvp in outputalpha)
            {
               Console.WriteLine(kvp);
            }
            Console.ReadLine();
        }
    }
}
