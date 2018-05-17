using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace laba_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Text.txt";
            StreamReader reader1 = new StreamReader(path, Encoding.GetEncoding(1251));
            string str_old = reader1.ReadToEnd(), str_new = "";
            Console.WriteLine("До перекодировки:\n{0}\n" ,str_old);
            reader1.Close();
            foreach (char c in str_old)
                str_new += char.ToLower(c);
            StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding(1251));
            writer.Write(str_new);
            writer.Close();
            StreamReader reader2 = new StreamReader(path, Encoding.GetEncoding(1251));
            Console.WriteLine("После перекодировки:\n{0}\n", reader2.ReadToEnd());
            reader2.Close();
            Console.ReadLine();
        }
    }
}
