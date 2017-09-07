using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication65
{
    class Program
    {
        /// <summary>
        /// Функция "добивания" двоичного кода до 8 знаков...
        /// </summary>
        /// <param name="s">Двоичный код символа</param>
        /// <returns>8 символов 2-ого кода символа</returns>
        public static string EightCode(string s) 
        {
            while (s.Length != 8) 
            {
                s = "0" + s;
            }
            return s;
        }
        /// <summary>
        /// Функция расчета позиций вставки дополнительных бит...
        /// </summary>
        /// <param name="bitdigit">Количество дополнительных бит...</param>
        /// <returns>Массив позиций для вставки...</returns>
        public static int[] Kvadratrelock(int bitdigit) 
        {
            int[] position = new int[bitdigit];
            for (int i = 0; i < bitdigit; i++) 
            {
                position[i] = Convert.ToInt32(Math.Pow(2,i))-1;
            }
            return position;
        }
        /// <summary>
        /// Функция постановки первоначальных бит по позициям...
        /// </summary>
        /// <param name="bitdigit">Количество доп.бит...</param>
        /// <param name="code">2-ый код символа кодируемой строки...</param>
        /// <returns>Строка с первоночальными доп. битами...</returns>
        public static string Insertbit(int[] bitdigit,string code) 
        {
            string s=code;
            foreach (int i in bitdigit) 
            {
                s = s.Insert(i, "*");
            }
            return s; 
        }
        /// <summary>
        /// Функция расчета контрольных сумм..
        /// </summary>
        /// <param name="s">Строка с первоначальными битами...</param>
        /// <param name="bitdigit">Количество доп.бит...</param>
        /// <returns>Закодированный символ...</returns>
        public static string ControlSum(string s,int bitdigit) 
        {
            int n = s.IndexOf("*");
            int control = 0;
            int h=0;
            while (h != bitdigit)
            {
                for (int i = n; i < s.Length; i += (2 * (n + 1)))
                {
                    for (int j = i; j < i + n + 1; j++)
                    {
                        try
                        {
                            if (s[j] != '*') control += Convert.ToInt32(Convert.ToString(s[j])); else control += 0;
                        }
                        catch { break; }
                    }
                }
                h++;
                if (control % 2.0 != 0)
                {
                    control = 1;
                    s=s.Remove(n, 1);
                    s=s.Insert(n, "1");
                }
                else
                {
                    control = 0;
                    s = s.Remove(n, 1);
                    s = s.Insert(n, "0");
                }
                control = 0;
                n = s.IndexOf("*");
            }
            return s;

        }
        static void Main(string[] args)
        {
            int bitdigit = 4;
            string alphavit = "abcdefghihklmnopqrstuvwxyzABCDEDGHIJKLMNOPQRSTUVWXYZ";
            int trualpha=0;
            int length=0;
            string input;
            do
            {
                Console.WriteLine("Введите,пожалуйста,кодируемую строку состающую из символов латинского алфавита");
                input = Console.ReadLine();
                trualpha = 0;
                length = input.Length;
                foreach (char c in input)
                {
                    if (alphavit.IndexOf(c) != -1) trualpha++;
                    else break;
                }
            } while (trualpha != length);
            Dictionary<char, string> collection = new Dictionary<char, string>();
            foreach (char c in input) 
            {
                if(!collection.ContainsKey(c)) collection.Add(c, EightCode(Convert.ToString(c,2)));
            }
            List<KeyValuePair<char,string>> hash=collection.ToList();
            Dictionary<char, string> output = new Dictionary<char, string>();
            foreach(KeyValuePair<char,string> kvp in hash)
            {
                string s= ControlSum(Insertbit(Kvadratrelock(bitdigit), kvp.Value), bitdigit);
                output.Add(kvp.Key, s);
            }
            foreach (KeyValuePair<char, string> kvp in output) 
            {
                Console.WriteLine(kvp);
            }
            Console.ReadLine();
            }
        }
    }
