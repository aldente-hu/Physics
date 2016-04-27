using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HirosakiUniversity.Aldente.MotionSimulation
{

	#region Vector構造体
	/// <summary>
	/// 2次元ベクトルを表す構造体です．
	/// 一般的に使えますが，要素名は1次元の位置と速度を意識しています(1次元での位相空間の元)．
	/// </summary>
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
	#endregion

	// IEnumerableの代わりにIDictionaryを使うと，yield returnが使えなかった！

	#region TimeVector構造体
	/// <summary>
	/// 時刻とベクトルを組み合わせた構造体です．
	/// </summary>
	public struct TimeVector
	{
		public double Time;
		public Vector Vector;

	}
	#endregion

}
