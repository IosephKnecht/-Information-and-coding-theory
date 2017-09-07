using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApplication55
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Huffman huf = new Huffman();
            huf.CreateTree(s);
            foreach (KeyValuePair<char, string> kvp in huf.Pop) 
            {
                Console.WriteLine(kvp);
            }
            Console.ReadLine();

        }
    }
}
