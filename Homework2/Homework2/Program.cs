using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            System.Console.Write("请输入一个整数:");
            s = Console.ReadLine();
            int a = 0;
            a = Int32.Parse(s);

            System.Console.Write(a + "的所有素因子包括");
            for(int i = 2; i <= a; i++)
            {
                if (a % i == 0 && isPrime(i))
                {
                    System.Console.Write(i+" ");
                   
                }
            }

        }
        public static Boolean isPrime(int a)
        {
            if (a <= 1) return false;
            for (int i = 2; i < a; i++)
                if (a % i == 0) return false;
            return true;
        }
    }
}
