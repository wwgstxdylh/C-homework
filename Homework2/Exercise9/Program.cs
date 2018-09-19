using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise9
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 100;
            Boolean[] a = new Boolean[N + 1];
            for (int i = 0; i <= N; i++) a[i] = true;
            for (int i = 2; i <= N; i++)
            {
                for (int j = 2 * i; j <= N; j += i)
                {
                    a[j] = false;
                }
            }
            for (int i = 2; i <= N; i++)
            {
                if (a[i]) System.Console.Write(i);
            }
        }
    }
}
