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

		public void GetCalculatedPoint(int x, int y, out int outX, out int outY)
		{
			outX = (int)(x * _matrix[0, 0] + y * _matrix[0, 1] + 1 * _matrix[0, 2]);
			outY = (int)(x * _matrix[1, 0] + y * _matrix[1, 1] + 1 * _matrix[1, 2]);
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
