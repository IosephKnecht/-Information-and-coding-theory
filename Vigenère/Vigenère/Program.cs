using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vigenère
{
    class Program
    {
        /// <summary>
        /// Процедура "подгонки" ключа под длину сообщения...
        /// </summary>
        /// <param name="key">Строковое значение ключа...</param>
        /// <param name="input">Слово необходимое зашифровать...</param>
        /// <returns>Строковое значение "подогнанного" ключа...</returns>
        public static string LengthKey(string key, string input)
        {
            string s = key;
            int i = 0;
            if (key.Length < input.Length)//Если длина ключа меньше длины шифруемого слова...
            {
                while (key.Length != input.Length)//Прибавляем символы к строке до тех пор,пока длины обоих входных параметров не станут одинаковыми...
                {
                    try
                    {
                        key += s[i];
                        i++;
                    }
                    catch
                    {
                        i = 0;
                    }
                }
            }
            return key;
        }
        /// <summary>
        /// Функция шифрования...
        /// </summary>
        /// <param name="input">Шифруемое слово...</param>
        /// <param name="key">Масштабированный ключ...</param>
        /// <returns>Зашифрованное слово...</returns>
        public static string Coding(string input, string key)
        {
            string output = null;
            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    int num = alphavit.IndexOf(input[i]) + alphavit.IndexOf(key[i]);//Номер символа,в соответствии с переходом...
                    output += alphavit[num];//Добавление символа в строку...
                }
                catch
                {
                    output += alphavit[alphavit.IndexOf(input[i]) + alphavit.IndexOf(key[i]) - alphavit.Length];
                    //Если номер символа в соответствии с переходом больше длины установленного алфавита...
                }
            }
            return output;
        }
        /// <summary>
        /// Функция декодирования сообщения...
        /// </summary>
        /// <param name="input">Зашифрованное слово...</param>
        /// <param name="key">Ключ...</param>
        /// <returns>Расшифрованное слово...</returns>
        public static string Decoding(string input, string key)
        {
            string output = null;
            for (int i = 0; i < input.Length; i++)
            {
                //Обратный процесс описанный в функции шифрования...
                try
                {
                    int num = alphavit.IndexOf(input[i]) - alphavit.IndexOf(key[i]);
                    output += alphavit[num];
                }
                catch
                {
                    output += alphavit[alphavit.Length + (alphavit.IndexOf(input[i]) - alphavit.IndexOf(key[i]))];
                }
            }
            return output;
        }
        public static string alphavit = "abcdefghijklmnopqrstuvwxyz";//Декларируемый алфавит...
        static void Main(string[] args)
        {
            bool sim = true;
            string input = null;
            do
            {
                Console.WriteLine("Введите,пожалуйста,сообщение латиницей");
                input = Console.ReadLine();
                sim = true;
                for (int i = 0; i < input.Length; i++)
                {
                    if (alphavit.IndexOf(Convert.ToString(input[i])) == -1)
                    {
                        sim = false;
                        break;
                    }
                }
            }
            while (sim == false);//Пока строка не соответствует заданному алфавиту...
            string key = Console.ReadLine();
            string k = (Coding(input, LengthKey(key, input)));
            Console.WriteLine(k);
            Console.WriteLine(Decoding(k, LengthKey(key, k)));
            Console.ReadLine();
        }
    }
}
