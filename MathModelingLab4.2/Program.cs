using System;
using System.Linq;
using MathNet.Numerics.Distributions;

class Program
{
	static void Main()
	{
		double[] x = { 11, 18, 18, 23, 32, 33, 34, 38, 35, 45, 62, 66, 61, 66, 65, 73, 74, 69, 70, 86, 79, 82, 162, 79, 91, 97, 145, 98, 98, 85, 101, 95, 101, 104, 117, 102, 116, 123, 133, 131 };
		double[] y = { 32, 29, 22, 25, 19, 18, 19, 22, 19, 20, 20, 18, 18, 18, 18, 19, 18, 18, 17, 19, 19, 19, 17, 18, 17, 19, 18, 18, 18, 17, 17, 17, 17, 18, 18, 18, 18, 18, 17, 18 };

		int n = x.Length;
		double meanX = x.Average();
		double meanY = y.Average();

		// Вычисление коэффициента корреляции rxy
		double numerator = x.Zip(y, (xi, yi) => (xi - meanX) * (yi - meanY)).Sum();
		double denominatorX = x.Sum(xi => Math.Pow(xi - meanX, 2));
		double denominatorY = y.Sum(yi => Math.Pow(yi - meanY, 2));
		double rxy = numerator / Math.Sqrt(denominatorX * denominatorY);

		// Вычисление индекса корреляции R (абсолютное значение rxy)
		double R = Math.Abs(rxy);

		// Проверка значимости коэффициента корреляции
		double alpha = 0.025;
		double t = rxy * Math.Sqrt((n - 2) / (1 - rxy * rxy));
		double tCritical = StudentT.InvCDF(0, 1, n - 2, 1 - alpha);
		bool isSignificant = Math.Abs(t) > tCritical;

		// Доверительный интервал для rxy
		double margin = tCritical * Math.Sqrt((1 - rxy * rxy) / (n - 2));
		double lowerBound = rxy - margin;
		double upperBound = rxy + margin;

		// Вывод результатов
		Console.WriteLine($"Коэффициент корреляции rxy: {rxy}");
		Console.WriteLine($"Индекс корреляции R: {R}");
		Console.WriteLine($"t-значение: {t}");
		Console.WriteLine($"Коэффициент корреляции значим: {isSignificant}");
		Console.WriteLine($"Доверительный интервал для rxy: [{lowerBound}, {upperBound}]");
	}
}
