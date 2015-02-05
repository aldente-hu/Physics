using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HirosakiUniversity.Aldente.MotionSimulation
{
	class Program
	{
		static void Main(string[] args)
		{
			var simulation = new RungeKutta();
			simulation.Force = (v, t) => new Vector { X = v.V, V = -143 * v.X - 0.3 * v.V + 0.1 * Math.Sin(11.81 * t) };
			simulation.Step = 0.001;


			using (StreamWriter writer = new StreamWriter(@"B:\data08-cs.csv"))
			{
				int i = 0;
				foreach (var vector in simulation.Do(new Vector { X = 0.0, V = 1.0 }, 25000))
				{
					//Console.WriteLine("{2:F3}   X={0:F4}   V={1:F4}", vector.Vector.X, vector.Vector.V, vector.Time);

					if (++i % 5 == 0)
					{
						writer.WriteLine("{2:F3},{0:F4},{1:F4}", vector.Vector.X, vector.Vector.V, vector.Time);
					}
					//writer.WriteLine("{2:F30},{0:F30},{1:F30},{3:F30}", vector.Vector.X, vector.Vector.V, vector.Time, Math.Sin(11.81 * vector.Time));

				}
			}
			Console.ReadLine();
		}

	}

}
