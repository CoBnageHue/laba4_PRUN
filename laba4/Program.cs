using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    internal class Program
    {
        public static StreamWriter sw = new StreamWriter("output.txt");
        static void Main(string[] args)
        {
            var arr = new[,] {
                {1, 2, 5, 4, 3, 6, 8, 7, 9, 10},
                {1, 2, 3, 7, 5, 6, 4, 8, 9, 10},
                {1, 5, 3, 4, 6 ,2, 10, 7, 8, 9},
                {1, 2, 4, 3, 5, 6, 7, 8, 9, 10},
                {1, 3, 2, 6, 5, 7, 4, 8, 9, 10},
                {1, 2, 3, 4, 7, 6, 5 ,8, 9, 10},
                {1, 5, 3, 4, 6, 2, 8, 7, 10, 9}
            };



            var result = new double[8];
            var r_all = .0;
            for (int i = 0; i < 8; i++)
            {
                if (i == 7) r_all = S_R(arr, i);
                else result[i] = S_R(arr, i);
            }

            var index = (Array.IndexOf(result, result.Max()) + 1);
            var result_index = Math.Round(result.Max(), 3);

            sw.WriteLine("Коэфициент конкордации всей группы R = " + Math.Round(r_all, 3) + ", наиболее согласованная группа - без эксперта е_"
                + index + ", R_" + index + " = " + result_index);
            sw.WriteLine();
            sw.Close();
        }

        static double S_R(int[,] arr, int value)
        {
            var sumRangs = new int[10];
            for (int i = 0; i < 10; i++)
            {
                var sum = 0;
                for (int j = 0; j < 7; j++)
                {
                    if (j == value)
                        continue;
                    sum += arr[j, i];
                }
                sumRangs[i] = sum;
            }
            var meanSum = sumRangs.Average();
            var minusRangs = new double[10];

            var S = .0;

            for (int i = 0; i < 10; i++)
            {
                minusRangs[i] = sumRangs[i] - meanSum;
                S += Math.Pow(minusRangs[i], 2);
            }
            var a = value == 7 ? 7 : 6;
            var R = (12 * S) / (Math.Pow(a, 2) * (1000 - 10));
            return R;

        }
    }
}
