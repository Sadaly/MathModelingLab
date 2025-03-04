using System;

class Program
{
	static void Main()
	{
		// Данные
		double[] x = { 1.25, 1.37, 1.49, 1.59, 1.63, 1.75, 1.88, 1.92 };
		double[] y = { 1.7, 2.9, 3.8, 4.6, 5.4, 6.3, 7.5, 8.7 };

		// Составляем систему уравнений для коэффициентов a0, a1 (линейная модель)
		double n = x.Length;
		double sumX = 0, sumY = 0, sumX2 = 0, sumXY = 0;

		for (int i = 0; i < n; i++)
		{
			sumX += x[i];
			sumY += y[i];
			sumX2 += x[i] * x[i];
			sumXY += x[i] * y[i];
		}

		// Решаем систему для нахождения коэффициентов a0, a1
		double denominator = n * sumX2 - sumX * sumX;
		double a0 = (sumY * sumX2 - sumX * sumXY) / denominator;
		double a1 = (n * sumXY - sumX * sumY) / denominator;

		// Выводим коэффициенты линейной модели
		Console.WriteLine($"Линейная модель: y = {a0} + {a1} * x");

		// Проверка адекватности модели (расчет R^2)
		double ssTotal = 0, ssRes = 0;
		for (int i = 0; i < n; i++)
		{
			double yPred = a0 + a1 * x[i];  // Предсказанное значение y
			ssTotal += (y[i] - sumY / n) * (y[i] - sumY / n);
			ssRes += (y[i] - yPred) * (y[i] - yPred);
		}

		double rSquared = 1 - (ssRes / ssTotal);
		Console.WriteLine($"Коэффициент детерминации R^2: {rSquared}");
	}
}
