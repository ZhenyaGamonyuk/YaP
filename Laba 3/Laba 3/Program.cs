using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3
{
    class Program
    {
        static void Main(string[] args)
        {
        label1:
            Console.WriteLine("Введите строку:");
            string str, temp_str;
            str = Console.ReadLine();
            if (Polindrom(str, out temp_str))
            {
                Console.WriteLine("{0} - палиндром", temp_str);
                goto label1;
            }
            else
            {
                Console.WriteLine("Не палиндром. {0}", temp_str);
                goto label1;
            }
        }
        static bool Polindrom(string str, out string temp_str)
        {
            string temp = "", upper_str = "", lower_str = "";
            for (int i = 0; i < str.Length; i++)
            {
                char a = str[i];
                if(Char.IsUpper(a) && !Char.IsNumber(a))
                {
                    upper_str += a;
                }
                if (Char.IsLower(a) && !Char.IsNumber(a))
                {
                    lower_str += a;
                }
            }
            for (int i = upper_str.Length - 1; i >= 0; i--)
            {
                temp += upper_str[i];
            }
            if (temp == upper_str && temp != "")
            {
                temp_str = upper_str;
                return true;
            }
            else
            {
                temp_str = lower_str;
                return false;
            }
        }
    }
}
