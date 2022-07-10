using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixStudy1
{
	internal class Matrix
	{
		public Matrix()
		{
			InitMatrix();
		}

		public void SetRotateMatrix(int angle)
		{
			var sin = (int)Math.Sin(angle * (Math.PI / 180));
			var cos = (int)Math.Cos(angle * (Math.PI / 180));

			_matrix[0, 0] = cos;
			_matrix[1, 1] = cos;
			_matrix[0, 1] = -sin;
			_matrix[1, 0] = sin;
		}

		public void SetMoveMatrix(int moveAmountX, int moveAmountY)
		{
			_matrix[0, 2] = moveAmountX;
			_matrix[1, 2] = moveAmountY;
		}

		public void SetScalarMatrix(double scalarAmount)
		{
			_matrix[0, 0] = scalarAmount;
			_matrix[1, 1] = scalarAmount;
		}

		public void GetCalculatedPoint(int x, int y, out int outX, out int outY)
		{
			outX = (int)(x * _matrix[0, 0] + y * _matrix[0, 1] + 1 * _matrix[0, 2]);
			outY = (int)(x * _matrix[1, 0] + y * _matrix[1, 1] + 1 * _matrix[1, 2]);
		}

		public void CalcMultMatrix(double[,] scalarMtrix)
		{
			var matrixBeforeCale = _matrix;
			var resultMatrix = new double[4, 4];

			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					for (int k = 0; k < 3; k++)
					{
						//乗算するときの順序に注意
						//後ろの行列から行われる（今回だと_matrix(回転・平行移動)後にscalarMtrix(拡縮)される
						resultMatrix[i, j] += scalarMtrix[i, k] * _matrix[k, j];
					}
				}
			}
			_matrix = resultMatrix;
		}

		private void InitMatrix()
		{
			_matrix = new double[3, 3]
			{
				{ 0,0,0 },
				{ 0,0,0 },
				{ 0,0,0 },
			};
		}

		public double[,] MatrixInfo => _matrix;
		private double[,] _matrix;
	}
}
