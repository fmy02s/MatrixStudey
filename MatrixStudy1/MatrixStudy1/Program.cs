using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixStudy1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = new Matrix();
            Console.WriteLine("座標を入力してください");
            
            Console.Write("X：");
            var x = int.Parse(Console.ReadLine());
            
            Console.Write("Y：");
            var y = int.Parse(Console.ReadLine());

            //Console.Write("Z：");
            //var z = Console.ReadLine();

            Console.WriteLine("角度を入力してください");
            var angle = int.Parse(Console.ReadLine());
            matrix.SetRotateMatrix(angle);
            matrix.GetCalculatedPoint(x, y, out var resultPointX, out var resultPointY);
            
            Console.WriteLine("行列を出力します。");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(matrix.MatrixInfo[i, j] + ", ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("回転後の座標を出力します。");
            Console.WriteLine("X = "+ resultPointX);
            Console.WriteLine("Y = " + resultPointY);


            Console.ReadLine();
        }
    }
}
