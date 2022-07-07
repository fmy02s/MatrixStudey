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
            Console.WriteLine("座標を入力してください");
            
            Console.Write("X：");
            var x = int.Parse(Console.ReadLine());
            
            Console.Write("Y：");
            var y = int.Parse(Console.ReadLine());

            //Console.Write("Z：");
            //var z = Console.ReadLine();

            Console.WriteLine("角度を入力してください");
            var angle = double.Parse(Console.ReadLine());

            var matrix = GetMatrix(angle);
            GetRotateCoordination(x, y, matrix, out var rotatedX, out var rotatedY);

            Console.WriteLine("行列を出力します。");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(matrix[i, j] + ", ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("回転後の座標を出力します。");
            Console.WriteLine("X = "+ rotatedX);
            Console.WriteLine("Y = " + rotatedY);


            Console.ReadLine();
        }

        public static void GetRotateCoordination(int x, int y , double[,] matrix, out int rotatedX, out int rotatedY)
        {
            rotatedX = (int)(x * matrix[0, 0] + y * matrix[0, 1]);
            rotatedY = (int)(x * matrix[1, 0] + y * matrix[1, 1]);

        }

        public static double[,] GetMatrix(double angle)
        {
            var matrix2D = new double[3, 3]
            {
                { 0,0,0 },
                { 0,0,0 },
                { 0,0,0 },
            };

            var sin = (int)Math.Sin(angle * (Math.PI / 180));
            var cos = (int)Math.Cos(angle * (Math.PI / 180));

            matrix2D[0, 0] = cos;
            matrix2D[1, 1] = cos;
            matrix2D[0, 1] = -sin;
            matrix2D[1, 0] = sin;

            return matrix2D;
        }
    }
}
