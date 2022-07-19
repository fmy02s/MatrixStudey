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
			var sin = (float)Math.Sin(angle * (Math.PI / 180));
			var cos = (float)Math.Cos(angle * (Math.PI / 180));

			_matrix[0, 0] = cos;
			_matrix[1, 1] = cos;
			_matrix[0, 1] = -sin;
			_matrix[1, 0] = sin;
		}

		public void SetMoveMatrix(float moveAmountX, float moveAmountY)
		{
			_matrix[0, 2] = moveAmountX;
			_matrix[1, 2] = moveAmountY;
		}

		public void SetScalarMatrix(float scalarAmount)
		{
			_matrix[0, 0] = scalarAmount;
			_matrix[1, 1] = scalarAmount;
		}

		public void GetCalculatedPoint(float x, float y, out float outX, out float outY)
		{
			outX = (x * _matrix[0, 0] + y * _matrix[0, 1] + 1 * _matrix[0, 2]);
			outY = (x * _matrix[1, 0] + y * _matrix[1, 1] + 1 * _matrix[1, 2]);
		}

		public void CalcMultMatrix(float[,] scalarMtrix)
		{
			var matrixBeforeCale = _matrix;
			var resultMatrix = new float[4, 4];

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
			_matrix = new float[3, 3]
			{
				{ 0,0,0 },
				{ 0,0,0 },
				{ 0,0,0 },
			};
		}

		public float[,] MatrixInfo => _matrix;
		private float[,] _matrix;
	}
}
