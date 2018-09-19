using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 7 };
            int sum = 0;
            int max = a[0];
            int min = a[0];
            for(int i = 0; i < 7; i++)
            {
                sum += a[i];
                if (max < a[i]) max = a[i];
                if (min > a[i]) min = a[i];
            }
            System.Console.Write("最大值:"+max);
            System.Console.Write("最小值:"+min);
            System.Console.Write("总和:"+sum);
            System.Console.Write("平均值:"+((double)sum/7));
        }
    }
}
