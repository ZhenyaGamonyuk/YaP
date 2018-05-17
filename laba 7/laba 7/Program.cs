using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_7
{
    class Program
    {
        private static Stack<int> stackOfNumbers = new Stack<int>();
        public static Stack<int> StackSort(Stack<int> stack)
        {
            List<int> temp = new List<int>();
            Stack<int> resultStack = new Stack<int>();
            int count = stack.Count;
            for (int i = 0; i < count; i++)
            {
                temp.Add(stack.Pop());
            }
            temp.Sort();
            for (int i = temp.Count - 1; i >= 0; i--)
            {
                resultStack.Push(temp[i]);
            }
            return resultStack;
        }
        public static string StackToString(Stack<int> stack, string str)
        {
            int count = 0;
            string temp = "";
            if (stack.Count == 1)
                temp = stack.Peek().ToString();
            else
            {
                foreach (var num in stack)
                {
                    count++;
                    if (count == stack.Count)
                        temp += num.ToString();
                    else
                        temp += num.ToString() + " - ";
                }
            }
            return string.Format("{0} {1}", str, temp);
        }
        static void Main(string[] args)
        {       
            Console.WriteLine("Введите кол-во:");
            int count = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите {0} элемент:", i+1);
                int number = Int32.Parse(Console.ReadLine());
                stackOfNumbers.Push(number);
            }
            Stack<int> tempStackOfNumbers = new Stack<int>(stackOfNumbers.Reverse());
            stackOfNumbers.Clear();
            stackOfNumbers = StackSort(tempStackOfNumbers);
            Console.WriteLine(StackToString(stackOfNumbers, "Стек:"));
            tempStackOfNumbers.Clear();
            label1:
            Console.WriteLine("Добавить элемент в стек:");
            int addNumber = Int32.Parse(Console.ReadLine());
            stackOfNumbers.Push(addNumber);
            tempStackOfNumbers = new Stack<int>(stackOfNumbers.Reverse());
            stackOfNumbers.Clear();
            stackOfNumbers = StackSort(tempStackOfNumbers);
            Console.WriteLine(StackToString(stackOfNumbers, "Стек:"));
            tempStackOfNumbers.Clear();
            goto label1;
        }
    }
}
