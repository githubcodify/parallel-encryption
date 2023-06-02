using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W14_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string raw = "abcdefghijklmnopqrstuvwxyz .?";
            string key = "wer tyuo.pasdfghjklizxc?vbnmq";
            string message = "hello. how are you today?hello. how are you today?hello. how are you today?hello. how are you today?";
            Console.WriteLine("Originial Message:");
            Console.WriteLine(message);

            string encMsg = EncryptParallel(raw, key, message);
            Console.WriteLine("\nEncrypted 1 Message:");
            Console.WriteLine(encMsg);

            encMsg = EncryptParallel(raw, key, encMsg);
            Console.WriteLine("\nEncrypted 2 Message:");
            Console.WriteLine(encMsg);

            string msg = EncryptParallel(key, raw, encMsg);
            Console.WriteLine("\nDecrypted 2 Message:");
            Console.WriteLine(msg);

            msg = EncryptParallel(key, raw, msg);
            Console.WriteLine("\nDecrypted 1 Message:");
            Console.WriteLine(msg);

            Console.ReadLine();
        }

        static string EncryptParallel(string raw, string key, string message)
        {
            char[] encMsg = new char[message.Length];
            Parallel.For(0, message.Length, (i) =>
            {
                int rawIndex = FindIndex(raw, message[i]);
                encMsg[i] = key[rawIndex];
            });
            return string.Join("", encMsg);
        }

        static int FindIndex(string x, char c)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == c)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
