using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HirosakiUniversity.Aldente.MotionSimulation
{

	#region RungeKuttaクラス
	public class RungeKutta
	{
		// 4次のルンゲクッタ法で，"次"のベクトルを得る関数です．
		static TimeVector GetNext(TimeVector timeVector, double step, Func<Vector, double, Vector> force)
		{
			var vector = timeVector.Vector;
			var previous_time = timeVector.Time;

			var k1 = step * force(vector, previous_time);
			var k2 = step * force(vector + k1 / 2, previous_time + step / 2);
			var k3 = step * force(vector + k2 / 2, previous_time + step / 2);
			var k4 = step * force(vector + k3, previous_time + step);
			return new TimeVector { Time = previous_time + step, Vector = vector + (k1 + 2 * k2 + 2 * k3 + k4) / 6 };
		}

		// とりあえずstaticで．

		#region *[static]ループ実行(DoLoop)
		/// <summary>
		/// 各ステップの，時系列ベクトルデータを返します．
		/// 各ステップの結果を返します．
		/// </summary>
		/// <param name="initialVector">初期ベクトル．</param>
		/// <param name="force">力を与える関数．(ベクトル,時刻) -> 力です．</param>
		/// <param name="step">ステップの時間間隔．</param>
		/// <param name="count">ステップを繰り返す回数．</param>
		/// <returns></returns>
		public static IEnumerable<TimeVector> DoLoop
			(Vector initialVector, Func<Vector, double, Vector> force, double step, int count = 10000)
		{
			//Vector vector = new Vector { X = 0.0, V = 1.0 };
			//Func<Vector, double, Vector> force = (v, t) => new Vector { X = v.V, V = -v.X };
			//double step = 0.01;

			var vector = new TimeVector { Time = 0, Vector = initialVector };

			for (int i = 0; i < count; i++)
			{
				vector = GetNext(vector, step, force);
				yield return vector;
			}
		}
		#endregion

		#region 以下，非static用．

		public Func<Vector, double, Vector> Force { get; set; }
		public Double Step { get; set; }


		public IEnumerable<TimeVector> Do(Vector initialVector, int count)
		{
			foreach (var vector in DoLoop(initialVector, this.Force, this.Step, count))
			{
				yield return vector;
			}
		}

		#endregion

	}
	#endregion

}
