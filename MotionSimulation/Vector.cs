using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HirosakiUniversity.Aldente.MotionSimulation
{
	public struct Vector
	{
		public double X;
		public double V;

		public static Vector operator +(Vector u, Vector v)
		{
			return new Vector { X = u.X + v.X, V = u.V + v.V };
		}

		public static Vector operator -(Vector u, Vector v)
		{
			// +と*から定義することもできるが...
			return new Vector { X = u.X - v.X, V = u.V - v.V };
		}

		/// <summary>
		/// スカラー倍．
		/// </summary>
		/// <param name="a"></param>
		/// <param name="u"></param>
		/// <returns></returns>
		public static Vector operator *(double a, Vector u)
		{
			return new Vector { X = a * u.X, V = a * u.V };
		}

		public static Vector operator /(Vector u, double a)
		{
			return (1 / a) * u;
		}
	}

	// IEnumerableの代わりにIDictionaryを使うと，yield returnが使えなかった！

	public struct TimeVector
	{
		public double Time;
		public Vector Vector;

	}

}
