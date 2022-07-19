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

            InputPoint(out var x, out var y);

            //回転角度
            InputRotateInfo(out var rotateAngle);
            matrix.SetRotateMatrix(rotateAngle);

			//平行移動
			InputMoveInfo(out float moveX, out float moveY);
			matrix.SetMoveMatrix(moveX, moveY);

			//拡縮
			var scalarmatrix = new Matrix();
			InputScalarInfo(out var scalar);
			scalarmatrix.SetScalarMatrix(scalar);

            //行列の合成
			matrix.CalcMultMatrix(scalarmatrix.MatrixInfo);

            //座標と行列の掛け算
			matrix.GetCalculatedPoint(x, y, out var resultPointX, out var resultPointY);

            OutputResultMatrix(matrix.MatrixInfo);
            OutputResultPoint(resultPointX, resultPointY);

            Console.ReadLine();
        }

        public static void InputPoint(out float pointX, out float pointY)
        {
            Console.WriteLine("座標を入力してください");

            Console.Write("X：");
            pointX = float.Parse(Console.ReadLine());

            Console.Write("Y：");
            pointY = float.Parse(Console.ReadLine());

            //Console.Write("Z：");
            //var z = Console.ReadLine();
        }

        public static void InputRotateInfo(out int rotateAngle)
        {
            Console.WriteLine("角度を入力してください。");
            Console.Write(" 角度：");
            rotateAngle = int.Parse(Console.ReadLine());
        }

        public static void InputMoveInfo(out float moveX, out float moveY)
        {
            Console.WriteLine("平行移動方向を入力してください。");
            Console.Write("　X方向：");
            moveX = float.Parse(Console.ReadLine());
            Console.Write("　Y方向：");
            moveY = float.Parse(Console.ReadLine());
        }

        public static void InputScalarInfo(out float scalar)
        {
            Console.WriteLine("拡大率を入力してください。");
            Console.Write("　拡大率：");
            scalar = float.Parse(Console.ReadLine());
        }

        public static void OutputResultMatrix(float[,] matrix)
        {
            Console.WriteLine("行列を出力します。");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(matrix[i, j] + ", ");
                }
                Console.WriteLine();
            }
        }

        public static void OutputResultPoint(float resultPointX, float resultPointY)
        {
            Console.WriteLine("回転後の座標を出力します。");
            Console.WriteLine("X = " + resultPointX);
            Console.WriteLine("Y = " + resultPointY);
        }
    }
}
